using Slink.Mapping;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Slink
{
    public static class Slink
    {
        static internal SlinkConfigOptions Options { get; private set; }

        public static void Init(SlinkConfigOptions options)
        {
            Options = options;

            ValidateDatabase();
        }

        public static SlinkConfigNamespace ConfigFor<T>()
        {
            return Options.Namespaces.FirstOrDefault(x => x.EntitiesNamespaces.Select(x => x.Namespace).Distinct().Contains(typeof(T).Namespace));
        }

        public static void ValidateDatabase()
        {
            Debug.WriteLine("Validating entities and properties types...");

            Debug.WriteLine("Validating schemas and procedures hashes...");

            // Entities procedures
            foreach (var @namespace in Options.Namespaces)
            {
                Debug.WriteLine($"Compiling procedures for {string.Join(", ", @namespace.EntitiesNamespaces.Select(x => x.Namespace).Distinct())}");

                var assemblies = @namespace.EntitiesNamespaces.Select(x => Assembly.GetAssembly(x)).ToList();
                assemblies.Add(Assembly.GetEntryAssembly());

                assemblies = assemblies.Distinct().ToList();

                var types = assemblies
                    .Select(x => x.ExportedTypes.Where(y => y.GetCustomAttributes<SlinkTableAttribute>().Any()))
                    .Aggregate(new List<Type>(), (x, y) => x.Concat(y).ToList());

                // TODO Cached loader and comparer - what strategy? files or database?

                using (var connection = @namespace.ConnectionFactory())
                {
                    connection.Open();

                    var command = connection.CreateCommand();

                    foreach (var type in types)
                    {
                        // Insert
                        if (!@namespace.Writer.SupportsCreateOrReplace)
                        {
                            command.CommandText = @namespace.Templates.DropProcedureTemplate
                                    .Replace("_#schema#_", @namespace.DatabaseSchema)
                                    .Replace("_#name#_", @namespace.GenerateEntityProcedureName(type, SlinkCrudOperation.Insert, null));
                            command.ExecuteNonQuery();
                        }

                        command.CommandText = BuildInsertProcedureSql(@namespace, type);
                        command.ExecuteNonQuery();

                        // GetById
                        // Update
                        // Upsert
                        // Delete
                        // So on...
                    }
                }

            }
        }

        private static string BuildInsertProcedureSql(SlinkConfigNamespace configNamespace, Type entityType)
        {
            var sql = configNamespace.Templates.ProcedureTemplate;

            var parameters = entityType.GetParameters(configNamespace);

            return sql
                .Replace("_#schema#_", configNamespace.DatabaseSchema)
                .Replace("_#name#_", configNamespace.GenerateEntityProcedureName(entityType, SlinkCrudOperation.Insert, null))
                .Replace("_#parameters#_", string.Join(",\n", configNamespace.Writer.ProcedureParameters(parameters)))
                .Replace("_#body#_", configNamespace.Writer.Insert(entityType).Sql.ToString())
                .Replace("_#hash#_", "<hash>");
        }

        public static void CreateReports()
        {
            Debug.WriteLine("Validating schemas and procedures hashes...");
        }
    }
}
