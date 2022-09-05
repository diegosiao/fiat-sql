using System;

namespace FiatSql.Mapping
{
    public class FiatTableAttribute : Attribute
    {
        public string Name { get; set; }

        public string PrimaryKey { get; set; }
    }
}
