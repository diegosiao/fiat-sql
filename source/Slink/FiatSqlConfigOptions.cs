using FiatSql.Vendors.MySql;
using Slink.Vendors;
using Slink.Vendors.Postgres;
using System;
using System.Collections.Generic;
using System.Data;

namespace Slink
{
    public class SlinkConfigNamespace
    {
        public SlinkVendors Vendor { get; internal set; }

        public Func<IDbConnection> ConnectionFactory { get; internal set; }

        public string[] ProceduresNamespaces { get; set; }

        /// <summary>
        /// At least one entity type for each mapped application namespace
        /// </summary>
        public Type[] EntitiesNamespaces { get; set; }

        public string DatabaseSchema { get; internal set; }

        public SlinkNamingPolicy NamingPolicy { get; set; }

        public bool SkipSchemaValidation { get; set; }

        public bool SkipProceduresValidation { get; set; }

        public Func<Type, SlinkCrudOperation, SlinkNamingPolicy?, string> GenerateEntityProcedureName { get; set; }

        private ISlinkTemplates _templates;

        internal ISlinkTemplates Templates
        {
            get
            {
                switch (Vendor)
                {
                    case SlinkVendors.Postgres:
                        return _templates ??= new PostgresTemplates();
                    case SlinkVendors.MySQL:
                        return _templates ??= new MySqlTemplates();
                    case SlinkVendors.SqlServer:
                    default:
                        throw new Exception();
                }
            }
        }

        private ISlinkSqlWriter _writer;

        public ISlinkSqlWriter Writer
        {
            get
            {
                switch (Vendor)
                {
                    case SlinkVendors.Postgres:
                        return _writer ??= new PostgresSqlWriter();
                    case SlinkVendors.MySQL:
                        return _writer ??= new MySqlWriter();
                    case SlinkVendors.SqlServer:
                    default:
                        throw new Exception($"Vendor not implemented {Vendor}");
                }
            }
        }

        internal SlinkConfigNamespace()
        {

        }
    }

    public class SlinkConfigOptions
    {
        public SlinkVendors Vendor { get; set; }

        /// <summary>
        /// If true, even queries and entity CRUD operations will be translated and compiled into Slink managed Stored Procedures.
        /// <para>Chances are this project will not support operations outside Stored Procedures because it is philosophically contradictory.</para>
        /// <para>Default value is true.</para>
        /// </summary>
        public bool StoredProceduresOnly { get; set; }

        /// <summary>
        /// The name of the table where mapping metada is kept
        /// </summary>
        public string ManagementTable { get; set; }

        public string EntityManagementTable { get; set; }

        public string ProcedureManagementTable { get; set; }

        public uint? DefaultIdentation { get; set; }

        public SlinkNamingPolicy NamingPolicy { get; set; }

        public List<SlinkConfigNamespace> Namespaces { get; set; }

        public Func<Type, SlinkCrudOperation, SlinkNamingPolicy?, string> GenerateEntityProcedureName { get; set; }


        public SlinkConfigOptions()
        {
            ManagementTable = "SlinkManagement".Np();
            EntityManagementTable = "SlinkManagementEntities".Np();
            ProcedureManagementTable = "SlinkManagementProcedures".Np();

            StoredProceduresOnly = true;

            GenerateEntityProcedureName = GenerateEntityProcedureNameDefault;
        }

        private string GenerateEntityProcedureNameDefault(Type type, SlinkCrudOperation operation, SlinkNamingPolicy? namingPolicy = null)
        {
            return $"ssp_{type.Name.Np(namingPolicy)}_{operation.ToString().Np(namingPolicy)}";
        }

        /// <summary>
        /// Bind one entity namespace or more to a specific database connection
        /// </summary>
        /// <param name="namespaces">Add at least one type for each mapped entities namespace</param>
        /// <param name="vendor"></param>
        /// <param name="connectionFactory"></param>
        /// <param name="namingPolicy"></param>
        /// <param name="skipSchemaValidation"></param>
        /// <param name="skipProceduresValidation"></param>
        public SlinkConfigOptions AddNamespaces(
            Type[] namespaces,
            SlinkVendors vendor, 
            string databaseSchema,
            Func<IDbConnection> connectionFactory,
            SlinkNamingPolicy namingPolicy = SlinkNamingPolicy.Lowercase,
            bool skipSchemaValidation = false,
            bool skipProceduresValidation = false)
        {
            Namespaces ??= new List<SlinkConfigNamespace>();

            Namespaces.Add(new SlinkConfigNamespace { 
                EntitiesNamespaces = namespaces,
                Vendor = vendor,
                DatabaseSchema = databaseSchema,
                ConnectionFactory = connectionFactory,
                NamingPolicy = namingPolicy,
                SkipSchemaValidation = skipSchemaValidation,
                SkipProceduresValidation = skipProceduresValidation,
                GenerateEntityProcedureName = GenerateEntityProcedureNameDefault,
            });

            return this;
        }
    }
}
