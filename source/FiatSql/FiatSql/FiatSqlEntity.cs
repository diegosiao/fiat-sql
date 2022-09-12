using Dapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FiatSql
{
    public class FiatSqlEntity<T>
    {
        public static T Insert(T entity, FiatSqlConfigOptions options = null)
        {
            var _options = options ?? FiatSql.Options;

            using (var connection = _options.ConnectionFactory())
            {
                var selectByIdSql = _options.Writer.SelectById<T>(entity);

                return connection.QueryFirstOrDefault<T>(
                        selectByIdSql.Sql,
                        selectByIdSql.Params);
            }
        }

        public static async Task<T> InsertAsync(T entity, FiatSqlConfigOptions options = null)
        {
            var _options = options ?? FiatSql.Options;

            using (var connection = _options.ConnectionFactory())
            {
                var selectByIdSql = _options.Writer.SelectById<T>(entity);

                return
                    await connection.QueryFirstOrDefaultAsync<T>(
                        selectByIdSql.Sql,
                        selectByIdSql.Params);
            }
        }

        public static T GetById(object id, FiatSqlConfigOptions options = null)
        {
            var _options = options ?? FiatSql.Options;

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
        public static async Task<T> GetByIdAsync(object id, FiatSqlConfigOptions options = null)
        {
            var _options = options ?? FiatSql.Options;

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

        /// <summary>
        /// Differently from 'Upsert' this method throws a 'SlinkEntityNotFoundException' if the entity does not exists.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="options"></param>
        public static T Update(T entity, FiatSqlConfigOptions options = null)
        {
            var _options = options ?? FiatSql.Options;

            using (var connection = _options.ConnectionFactory())
            {
                var selectByIdSql = _options.Writer.SelectById<T>(entity.GetIdValue<T>());

                return connection.QueryFirstOrDefault<T>(
                        selectByIdSql.Sql,
                        selectByIdSql.Params);
            }
        }

        public static async Task<T> UpdateAsync(T entity, FiatSqlConfigOptions options = null)
        {
            var _options = options ?? FiatSql.Options;

            using (var connection = _options.ConnectionFactory())
            {
                var selectByIdSql = _options.Writer.SelectById<T>(entity.GetIdValue<T>());

                return
                    await connection.QueryFirstOrDefaultAsync<T>(
                        selectByIdSql.Sql,
                        selectByIdSql.Params);
            }
        }

        public static void Update(Expression<Func<T, object>> columns)
        {

        }

        public static T Upsert(T entity, FiatSqlConfigOptions options = null)
        {
            var _options = options ?? FiatSql.Options;

            using (var connection = _options.ConnectionFactory())
            {
                var selectByIdSql = _options.Writer.SelectById<T>(entity.GetIdValue<T>());

                return connection.QueryFirstOrDefault<T>(
                        selectByIdSql.Sql,
                        selectByIdSql.Params);
            }
        }

        public static async Task<T> UpsertAsync(T entity, FiatSqlConfigOptions options = null)
        {
            var _options = options ?? FiatSql.Options;

            using (var connection = _options.ConnectionFactory())
            {
                var selectByIdSql = _options.Writer.SelectById<T>(entity.GetIdValue<T>());

                return
                    await connection.QueryFirstOrDefaultAsync<T>(
                        selectByIdSql.Sql,
                        selectByIdSql.Params);
            }
        }

        public static T Delete(object id, FiatSqlConfigOptions options = null)
        {
            var _options = options ?? FiatSql.Options;

            using (var connection = _options.ConnectionFactory())
            {
                var selectByIdSql = _options.Writer.SelectById<T>(id);

                return connection.QueryFirstOrDefault<T>(
                        selectByIdSql.Sql,
                        selectByIdSql.Params);
            }
        }

        public static async Task<T> DeleteAsync(object id, FiatSqlConfigOptions options = null)
        {
            var _options = options ?? FiatSql.Options;

            using (var connection = _options.ConnectionFactory())
            {
                var selectByIdSql = _options.Writer.SelectById<T>(id);

                return
                    await connection.QueryFirstOrDefaultAsync<T>(
                        selectByIdSql.Sql,
                        selectByIdSql.Params);
            }
        }
    }
}
