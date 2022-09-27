using Slink.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Slink.Vendors.Postgres
{
    public class PostgresSqlWriter : ISlinkSqlWriter
    {
        public bool SupportsCreateOrReplace => true;

        public SlinkParseResult If(string sqlCondition)
        {
            var sqlResult = new SlinkParseResult();
            sqlResult.Sql.AppendLine($"IF ({sqlCondition}) THEN ");
            sqlResult.Sql.AppendLine($"   {sqlCondition ?? "NULL;"}");
            sqlResult.Sql.AppendLine($"END IF");
            return sqlResult;
        }

        public IEnumerable<string> ProcedureParameters(IEnumerable<FiatDbParameter> parameters)
        {
            foreach (FiatDbParameter parameter in parameters)
            {
                yield return $"{parameter.ParameterName} {ParameterDirectionToString(parameter.Direction)} {DbTypeToString(parameter)}";
            }
        }

        public static string ParameterDirectionToString(ParameterDirection direction)
        {
            switch (direction)
            {
                case ParameterDirection.Input:
                    return "in";
                case ParameterDirection.Output:
                    return "out";
                case ParameterDirection.InputOutput:
                    return "inout";
                case ParameterDirection.ReturnValue:
                    return "return";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string DbTypeToString(FiatDbParameter parameter)
        {
            var typeArgFullName = parameter.PropertyInfo.PropertyType.FullName;

            if (typeArgFullName.StartsWith("System.Nullable`1["))
            {
                typeArgFullName = parameter.PropertyInfo.PropertyType.GenericTypeArguments.FirstOrDefault().FullName;
            }

            switch (typeArgFullName)
            {
                case "System.String":
                    // return $"varchar({(parameter.Size <= 0 ? 1024 : parameter.Size)})";
                    return "text";
                case "System.DateTime":
                    parameter.DbType = DbType.DateTime;
                    return "timestamptz";
                case "System.Boolean":
                    parameter.DbType = DbType.Boolean;
                    parameter.Size = 1;
                    return "boolean";
                case "System.Guid":
                    parameter.DbType = DbType.Guid;
                    return "uuid";
                case "System.Int32":
                case "System.Decimal":
                    parameter.DbType = DbType.Decimal;
                    return "numeric";
                default:
                    throw new DatabaseVendorDbTypeNotSupportedException(parameter.DbType);
            }
        }

        public SlinkParseResult SelectById<TEntity>(object id)
        {
            var map = FiatCache.GetMap<TEntity>();

            var sqlResult = new SlinkParseResult();
            sqlResult.Sql.Append($"SELECT * FROM {map.TableName} WHERE {map.PkColumnName} = :pId");
            sqlResult.Params.Add(new FiatDbParameter("pId", id));

            return sqlResult;
        }

        public SlinkParseResult Insert(Type entityType, object entity = null)
        {
            var parseResult = new SlinkParseResult();
            var entityName = entityType.Name;

            var fiatTableAttribute = entityType.GetCustomAttributes(true).FirstOrDefault(x => x is SlinkTableAttribute) as SlinkTableAttribute;

            if (fiatTableAttribute != null)
            {
                entityName = fiatTableAttribute.Name;
            }

            var props = entityType
                .GetProperties()
                .Select(prop => new
                {
                    PropertyInfo = prop,
                    prop.Name,
                    ParameterName = prop.Name.ToLower(),
                    Value = entityType.Equals(entity?.GetType()) ? prop.GetValue(entity) : null,
                })
                .ToArray();

            parseResult.Sql.AppendLine($"INSERT INTO {entityName} (");

            foreach (var prop in props)
            {
                parseResult.Sql.AppendLine($"  {prop.Name},");

                var parameter = new FiatDbParameter
                {
                    ParameterName = prop.ParameterName,
                    Direction = ParameterDirection.Input,
                    DbType = DbType.String,
                    PropertyInfo = prop.PropertyInfo,
                    Value = prop.Value,
                };

                DbTypeToString(parameter);

                parseResult.Params.Add(parameter);
            }

            parseResult.Sql = parseResult.Sql.Remove(parseResult.Sql.Length - 3, 3);

            parseResult.Sql.AppendLine(")");
            parseResult.Sql.AppendLine("VALUES (");

            foreach (var prop in props)
            {
                if (prop.Name.Equals("CreatedBy"))
                {
                    parseResult.Sql.AppendLine($"  user,");
                }
                else
                {
                    parseResult.Sql.AppendLine($"  {prop.ParameterName},");
                }
            }

            parseResult.Sql = parseResult.Sql.Remove(parseResult.Sql.Length - 3, 3);
            parseResult.Sql.Append(");");

            return parseResult;
        }
    }
}
