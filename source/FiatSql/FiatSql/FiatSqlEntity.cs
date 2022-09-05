using Dapper;
using System.Collections.Generic;

namespace FiatSql
{
    public class FiatSqlEntity<T>
    {
        public static T GetById(object id, FiatSqlConfigOptions options = null)
        {
            var _options = options ?? FiatSql.Options;

            using (var connection = _options.ConnectionFactory())
            {
                return connection.QueryFirstOrDefault<T>("SELECT * FROM public.person");
            }
        }

        public static IEnumerable<T> GetAll()
        {
            return default(List<T>);
        }
    }
}
