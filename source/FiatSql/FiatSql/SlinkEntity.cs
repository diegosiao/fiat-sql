using Dapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Slink
{
    public class SlinkEntity<T>
    {
        /* 
         * static versions [SlinkEntity].(...):
            - GetById(), GetAllById(), GetAll(), GetAllWhere()
            - UpdateAllById(), UpdateAllWhere()
            - DeleteById(), DeleteAllById();
        */

        public T Insert(SlinkConfigOptions options = null)
        {
            var _options = options ?? Slink.Options;

            using (var connection = _options.ConnectionFactory())
            {
                var selectByIdSql = _options.Writer.SelectById<T>(this);

                return connection.QueryFirstOrDefault<T>(
                        selectByIdSql.Sql,
                        selectByIdSql.Params);
            }
        }

        public async Task<T> InsertAsync(SlinkConfigOptions options = null)
        {
            var _options = options ?? Slink.Options;

            using (var connection = _options.ConnectionFactory())
            {
                var selectByIdSql = _options.Writer.SelectById<T>(this);

                return
                    await connection.QueryFirstOrDefaultAsync<T>(
                        selectByIdSql.Sql,
                        selectByIdSql.Params);
            }
        }

        public static T GetById(object id, SlinkConfigOptions options = null)
        {
            var _options = options ?? Slink.Options;

            using (var connection = _options.ConnectionFactory())
            {
                var selectByIdSql = _options.Writer.SelectById<T>(id);

                return connection.QueryFirstOrDefault<T>(
                        selectByIdSql.Sql,
                        selectByIdSql.Params);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="options"></param>
        public static async Task<T> GetByIdAsync(object id, SlinkConfigOptions options = null)
        {
            var _options = options ?? Slink.Options;

            using (var connection = _options.ConnectionFactory())
            {
                var selectByIdSql = _options.Writer.SelectById<T>(id);

                return
                    await connection.QueryFirstOrDefaultAsync<T>(
                        selectByIdSql.Sql,
                        selectByIdSql.Params);
            }
        }
        public static IEnumerable<T> GetAll(uint? pageSize = 50, uint? pageNumber = 1)
        {
            return default(List<T>);
        }

        public static async Task<IEnumerable<T>> GetAllAsync(uint? pageSize = 50, uint? pageNumber = 1)
        {
            return await Task.FromResult(new List<T>());
        }

        /// <summary>
        /// Differently from 'Upsert' this method throws a 'SlinkEntityNotFoundException' if the entity does not exists.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="options"></param>
        public T Update(SlinkConfigOptions options = null)
        {
            var _options = options ?? Slink.Options;

            using (var connection = _options.ConnectionFactory())
            {
                var selectByIdSql = _options.Writer.SelectById<T>(this.GetIdValue());

                return connection.QueryFirstOrDefault<T>(
                        selectByIdSql.Sql,
                        selectByIdSql.Params);
            }
        }

        public async Task<T> UpdateAsync(SlinkConfigOptions options = null)
        {
            var _options = options ?? Slink.Options;

            using (var connection = _options.ConnectionFactory())
            {
                var selectByIdSql = _options.Writer.SelectById<T>(this.GetIdValue());

                return
                    await connection.QueryFirstOrDefaultAsync<T>(
                        selectByIdSql.Sql,
                        selectByIdSql.Params);
            }
        }

        public void Update(Expression<Func<T, object>> columns)
        {

        }

        public T Upsert(SlinkConfigOptions options = null)
        {
            var _options = options ?? Slink.Options;

            using (var connection = _options.ConnectionFactory())
            {
                var selectByIdSql = _options.Writer.SelectById<T>(this.GetIdValue());

                return connection.QueryFirstOrDefault<T>(
                        selectByIdSql.Sql,
                        selectByIdSql.Params);
            }
        }

        public async Task<T> UpsertAsync(SlinkConfigOptions options = null)
        {
            var _options = options ?? Slink.Options;

            using (var connection = _options.ConnectionFactory())
            {
                var selectByIdSql = _options.Writer.SelectById<T>(this.GetIdValue());

                return
                    await connection.QueryFirstOrDefaultAsync<T>(
                        selectByIdSql.Sql,
                        selectByIdSql.Params);
            }
        }

        public T Delete(SlinkConfigOptions options = null)
        {
            var _options = options ?? Slink.Options;

            using (var connection = _options.ConnectionFactory())
            {
                var selectByIdSql = _options.Writer.SelectById<T>(this.GetIdValue());

                return connection.QueryFirstOrDefault<T>(
                        selectByIdSql.Sql,
                        selectByIdSql.Params);
            }
        }

        public async Task<T> DeleteAsync(SlinkConfigOptions options = null)
        {
            var _options = options ?? Slink.Options;

            using (var connection = _options.ConnectionFactory())
            {
                var selectByIdSql = _options.Writer.SelectById<T>(this.GetIdValue());

                return
                    await connection.QueryFirstOrDefaultAsync<T>(
                        selectByIdSql.Sql,
                        selectByIdSql.Params);
            }
        }
    }
}
