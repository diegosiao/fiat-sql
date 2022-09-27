using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Slink
{
    public abstract class SlinkEntityBase { }

    public class SlinkEntity<T> : SlinkEntityBase
    {
        /* 
         static versions [SlinkEntity].(...):
            - GetById(), GetAllById(), GetAll(), GetAllWhere()
            - UpdateAllById(), UpdateAllWhere()
            - DeleteById(), DeleteAllById();
        */

        public T Insert(SlinkConfigOptions options = null)
        {
            var _options = Slink.ConfigFor<T>();

            var sqlResult = _options.Writer.Insert(typeof(T), this);
            
            var dynamicParams = new DynamicParameters();

            foreach(var parameter in sqlResult.Params)
            {
                dynamicParams.Add(
                    parameter.ParameterName, 
                    parameter.Value, 
                    parameter.DbType, 
                    parameter.Direction,
                    parameter.Size);
            }

            // OnBeforeInsert(this);

            using (var connection = _options.ConnectionFactory())
            {
                connection.Execute(
                    _options.GenerateEntityProcedureName.Invoke(GetType(), SlinkCrudOperation.Insert, null),
                    param: dynamicParams,
                    commandType: CommandType.StoredProcedure);
            }

            // OnAfterInsert(this);

            return (T)(object)this;
        }

        public async Task<T> InsertAsync(SlinkConfigOptions options = null)
        {
            Console.WriteLine("WIP InsertAsync");
            return await Task.FromResult(default(T));
        }

        public static T GetById(object id, SlinkConfigOptions options = null)
        {
            Console.WriteLine("WIP GetById");
            return default(T);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="options"></param>
        public static async Task<T> GetByIdAsync(object id, SlinkConfigOptions options = null)
        {
            Console.WriteLine("WIP GetByIdAsync");
            return await Task.FromResult(default(T));
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
            Console.WriteLine("WIP Update");
            return default(T);
        }

        public async Task<T> UpdateAsync(SlinkConfigOptions options = null)
        {
            Console.WriteLine("WIP UpdateAsync");
            return await Task.FromResult(default(T));
        }

        public void Update(Expression<Func<T, object>> columns)
        {
            Console.WriteLine("NOT IMPLEMENTED: Update");

            // TODO Make it happen

            //await PersonEntity
            //    .Update(DemonstrationData.AnnaSmith)
            //    .Set(x => x.Birth, new DateTime(1981, 10, 10))
            //    .Set(x => x.Salary, 21851M)
            //    .Where(x => x.Id != null)
            //    .And(x => x.Birth > new DateTime(1980, 01, 01))
            //    .ExecAsync(exceptionIfNotFound: false);
        }

        public T Upsert(SlinkConfigOptions options = null)
        {
            Console.WriteLine("WIP Upsert");
            return default(T);
        }

        public async Task<T> UpsertAsync(SlinkConfigOptions options = null)
        {
            Console.WriteLine("WIP UpsertAsync");
            return await Task.FromResult(default(T));
        }

        public T Delete(SlinkConfigOptions options = null)
        {
            Console.WriteLine("WIP Delete");
            return default(T);
        }

        public async Task<T> DeleteAsync(SlinkConfigOptions options = null)
        {
            Console.WriteLine("WIP DeleteAsync");
            return await Task.FromResult(default(T));
        }
    }
}
