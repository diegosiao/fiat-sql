using FiatSql.Mapping;
using System.Linq;

namespace FiatSql
{
    public class FiatInsert<TEntity> : FiatCrudOperation<TEntity>
    {
        public FiatInsert(TEntity entity, string entityParamName = null) : base(entity)
        {
            var entityName = typeof(TEntity).Name;

            var fiatTableAttribute = entity.GetType().GetCustomAttributes(true).FirstOrDefault(x => x is FiatTableAttribute);

            if (fiatTableAttribute != null)
            {
                entityName = ((FiatTableAttribute)fiatTableAttribute).Name;
            }

            var props = typeof(TEntity)
                .GetProperties()
                .Select(prop => new 
                { 
                    PropertyInfo = prop,
                    prop.Name, 
                    ParameterName = $"{entityParamName ?? typeof(TEntity).Name}_{prop.Name}".ToLower(),
                    Value = prop.GetValue(entity), 
                })
                .ToArray();

            Sql.AppendLine($"INSERT INTO {entityName} (");

            foreach(var prop in props)
            {
                Sql.AppendLine($"  {prop.Name},");
                Parameters.Add(new FiatDbParameter
                {
                    ParameterName = prop.ParameterName,
                    Direction = System.Data.ParameterDirection.Input,
                    DbType = System.Data.DbType.String,
                    PropertyInfo = prop.PropertyInfo,
                    Value = prop.Value,
                });
            }

            Sql = Sql.Remove(Sql.Length - 3, 3);

            Sql.AppendLine(")");
            Sql.AppendLine("VALUES (");

            foreach (var prop in props)
            {
                if (prop.Name.Equals("CreatedBy"))
                {
                    Sql.AppendLine($"  user,");
                }
                else
                {
                    Sql.AppendLine($"  {prop.ParameterName},");
                }
            }

            Sql = Sql.Remove(Sql.Length - 3, 3);
            Sql.Append(");");
        }
    }
}
