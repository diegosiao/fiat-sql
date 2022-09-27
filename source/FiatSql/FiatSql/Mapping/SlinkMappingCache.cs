using System.Collections.Generic;

namespace Slink.Mapping
{
    public class SlinkMappingCache
    {
        public static Dictionary<string, SlinkMappingCache> Namespaces { get; private set; }

        public string EntitiesNamespace { get; private set; }

        public SlinkVendors DatabaseVendor { get; set; }

        public List<SlinkMappingEntityNode> Entities { get; set; }

        private SlinkMappingCache()
        {
            Namespaces ??= new Dictionary<string, SlinkMappingCache>();
        }

        internal void AddSlinkMapping(string entitiesNamespace, List<SlinkMappingEntityNode> entities, SlinkVendors fiatSqlVendors)
        {
            Namespaces.Add(entitiesNamespace, new SlinkMappingCache
            {
                DatabaseVendor = fiatSqlVendors,
                Entities = entities,
                EntitiesNamespace = entitiesNamespace,
            });
        }

        public void AddCustomMapping()
        {

        }
    }
}
