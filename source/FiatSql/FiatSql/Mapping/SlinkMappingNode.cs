using System;

namespace Slink.Mapping
{
    public abstract class SlinkMappingNode
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Custom { get; set; }
    }
}
