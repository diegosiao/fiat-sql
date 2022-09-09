using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FiatSql.Vendors.Postgres.v14
{
    public class PostgresSqlWriter : IFiatSqlWriter
    {
        public FiatSqlParseResult If(string sqlCondition)
        {
            return new FiatSqlParseResult
            {
                Sql =
                $"IF ({sqlCondition}) THEN " +
                $"   {sqlCondition ?? "NULL;"}" +
                "END IF"
            };
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

        public FiatSqlParseResult SelectById<TEntity>(object id)
        {
            var map = FiatCache.GetMap<TEntity>();

            var sqlResult = new FiatSqlParseResult
            {
                Sql = $"SELECT * FROM {map.TableName} WHERE {map.PkColumnName} = :pId",
                Params = new FiatDbParameter[] { 
                    new FiatDbParameter("pId", id)
                }
            };

            return sqlResult;
        }
    }
}
