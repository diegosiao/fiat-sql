using System;

namespace Slink
{
    internal class SlinkMissingIdPropertyException : Exception
    {
        new public string Message { get; set; }

        public SlinkMissingIdPropertyException(Type entityType)
        {
            Message = $"The 'Id' property is required to uniquely identify entities. Entity: {entityType.FullName}";
        }
    }
}
