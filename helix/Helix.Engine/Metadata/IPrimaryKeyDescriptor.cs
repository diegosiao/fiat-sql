using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.Engine.Metadata
{
    internal interface IPrimaryKeyDescriptor
    {
        string Name { get; }

        Type DotnetType { get; }

        string DatabaseType { get; }
    }
}
