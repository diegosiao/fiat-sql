using Slink;
using Slink.Mapping;
using Slink.Vendors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FiatSql.Vendors.MySql
{
    internal class MySqlWriter : ISlinkSqlWriter
    {
        public bool SupportsCreateOrReplace => false;

        public SlinkParseResult If(string sqlCondition)
        {
            throw new NotImplementedException();
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
                    parseResult.Sql.AppendLine($"  user(),");
                }
                else if (prop.PropertyInfo.PropertyType == typeof(Guid) || prop.PropertyInfo.PropertyType == typeof(Guid?))
                {
                    parseResult.Sql.AppendLine($"  UUID_TO_BIN({prop.ParameterName}),");
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

        public IEnumerable<string> ProcedureParameters(IEnumerable<FiatDbParameter> parameters)
        {
            foreach (FiatDbParameter parameter in parameters)
            {
                yield return $"{ParameterDirectionToString(parameter.Direction)} {parameter.ParameterName} {DbTypeToString(parameter)}";
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
                    return "timestamp";
                case "System.Boolean":
                    parameter.DbType = DbType.Boolean;
                    parameter.Size = 1;
                    return "bit";
                case "System.Guid":
                    parameter.DbType = DbType.Guid;
                    return "text";
                case "System.Int32":
                    parameter.DbType = DbType.Int32;
                    return "integer";
                case "System.Decimal":
                    parameter.DbType = DbType.Decimal;
                    return "numeric";
                default:
                    throw new DatabaseVendorDbTypeNotSupportedException(parameter.DbType);
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

        public SlinkParseResult SelectById<TEntity>(object id)
        {
            throw new NotImplementedException();
        }
    }
}
