using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.Engine.Metadata.Postgres
{
    internal class PostgresTableDescriptor : ITableDescriptor
    {
        public string Schema { get; private set; }
        public string Name { get; private set; }
        public IDatabaseTypeDescriptor PrimaryKeyDescriptor { get; private set; }
        public IEnumerable<IColumnDescriptor> Columns { get; private set; }

        public PostgresTableDescriptor(string schema, string name, IEnumerable<PostgresColumnDescriptor> columns)
        {
            Schema = schema;
            Name = name;
            Columns = columns;
        }
    }
}
