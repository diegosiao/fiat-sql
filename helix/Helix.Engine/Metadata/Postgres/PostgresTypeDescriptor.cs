using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.Engine.Metadata.Postgres
{
    internal class PostgresTypeDescriptor : IDatabaseTypeDescriptor
    {
        public string Name {get; private set;}

        public Type ApplicationType { get; private set; }

        public PostgresTypeDescriptor(string name, Type applicationType) 
        {
            Name = name;
            ApplicationType = applicationType;
        }
    }
}
