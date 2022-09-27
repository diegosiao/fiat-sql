using System;
using System.Collections.Generic;

namespace Slink.Mapping
{
    public class SlinkMappingEntityNode : SlinkMappingNode
    {
        public Type EntityType { get; set; }

        public string EntityName { get; set; }



        public List<SlinkMappingPropertyNode> Properties { get; set; }
    }
}
