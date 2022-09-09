using FiatSql.Mapping;
using System.Collections.Generic;
using System.Reflection;

namespace FiatSql
{
    internal static class FiatCache
    {
        static Dictionary<string, FiatEntityMap> Entities { get; set; }

        static FiatCache()
        {
            Entities = new Dictionary<string, FiatEntityMap>();
        }

        public static FiatEntityMap GetMap<T>()
        {
            if(Entities.TryGetValue(typeof(T).FullName, out FiatEntityMap map))
            {
                return map;
            }

            map = new FiatEntityMap();

            var entityType = typeof(T);
            var tableAttribute = entityType.GetCustomAttribute<FiatTableAttribute>();

            var idProp = entityType.GetProperty("Id");

            if (idProp == null)
                throw new FiatMissingIdPropertyException(entityType);

            if(tableAttribute != null)
            {
                map.TableName = tableAttribute.Name;
                map.PkColumnName = tableAttribute.PrimaryKey ?? "Id".Np();
            }

            Entities.Add(entityType.FullName, map);

            return map;
        }
    }
}
