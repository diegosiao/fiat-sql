using Helix.Common;
using Dapper;
using Helix.Common.Configuration;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.Common;

namespace Helix.Core
{
    public class HelixExecute
    {
        private readonly DatabaseConfiguration _configuration;

        public HelixExecute(DatabaseConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public async Task<object?> InsertAsync(DbTuple item)
        {
            if (item == null)
                return null;

            if (!item.BeforeInsert())
            {
                return null;
            }

            using (var connection = ConnectionFactory.GetNew(_configuration.ConnectionString, DatabaseVendor.Postgres))
            {
                connection.Open();
                var result = await connection.QueryAsync(item.GetInsertTemplate(), item);

                if(result != null)
                {
                    return result.FirstOrDefault()?.id;
                }

                return null;
            }
        }

        public async Task ExecuteBatch(params DbBatchCommand[] commands)
        {
            /* transaction implied */
        }

        public async Task<T> GetByIdAsync<T>(object id)
        {
            using (var connection = ConnectionFactory.GetNew(_configuration.ConnectionString, DatabaseVendor.Postgres))
            {
                connection.Open();

                return await connection.QueryFirstOrDefaultAsync<T>(
                    $"SELECT * FROM {typeof(T).Name} WHERE id = @id", new { id });
            }
        }
    }
}
