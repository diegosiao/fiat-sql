using System;

namespace FiatSql
{
    internal class FiatMissingIdPropertyException : Exception
    {
        new public string Message { get; set; }

        public FiatMissingIdPropertyException(Type entityType)
        {
            Message = $"The 'Id' property is required to uniquely identify entities. Entity: {entityType.FullName}";
        }
    }
}
