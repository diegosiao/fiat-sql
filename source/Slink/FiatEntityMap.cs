using System;

namespace Slink
{
    internal class FiatEntityMap
    {
        public string TableName { get; set; }

        public string PkColumnName { get; set; }

        public Type PkDotnetType { get; set; }
    }
}
