using System;

namespace Slink.Mapping
{
    public class SlinkMappingPropertyNode : SlinkMappingNode
    {
        public Type PropertyType { get; set; }

        public SlinkMappingColumnNode DatabaseColumn { get; set; }
    }
}
