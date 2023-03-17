using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.Engine.Metadata.Postgres
{
    internal class PostgresColumnDescriptor : IColumnDescriptor
    {
        public string Schema { get; internal set; }

        public string Table { get; internal set; }

        public string Name { get; internal set; }

        public int OrdinalPosition { get; set; }

        public bool IsNullable { get; internal set; }

        public string? Comment { get; internal set; }

        public string? References { get; internal set; }

        public int? Length { get; internal set; }
        
        public bool IsPrimaryKey { get; internal set; }

        public IDatabaseTypeDescriptor TypeDescriptor { get; internal set; }

        public bool HasDefault { get; internal set; }

        public PostgresColumnDescriptor()
        {
            
        }
    }
}
