using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Helix.Engine.Metadata.Postgres
{
    internal static class PostgresSupportedTypes
    {
        internal const string CHARACTER_VARYING = "character varying";

        internal const string INT4 = "int4";

        internal const string INTEGER = "integer";

        internal const string TIMESTAMP = "timestamp";

        internal const string TIMESTAMP_WITHOUT_TIME_ZONE = "timestamp without time zone";

        internal const string FLOAT = "float";

        internal const string UUID = "uuid";

        internal const string DATE = "date";

        internal const string NUMERIC = "numeric";

        internal const string BOOLEAN = "boolean";

        internal static Dictionary<string, PostgresTypeDescriptor> Types { get; private set; }

        static PostgresSupportedTypes()
        {
            Types = new Dictionary<string, PostgresTypeDescriptor>
            {
                {
                    CHARACTER_VARYING, new PostgresTypeDescriptor(CHARACTER_VARYING, typeof(string))
                },
                {
                    INT4, new PostgresTypeDescriptor(INT4, typeof(int))
                },
                {
                    NUMERIC, new PostgresTypeDescriptor(NUMERIC, typeof(decimal))
                },
                {
                    INTEGER, new PostgresTypeDescriptor(INTEGER, typeof(int))
                },
                {
                    TIMESTAMP, new PostgresTypeDescriptor(TIMESTAMP, typeof(DateTime))
                },
                {
                    TIMESTAMP_WITHOUT_TIME_ZONE, new PostgresTypeDescriptor(TIMESTAMP_WITHOUT_TIME_ZONE, typeof(DateTime))
                },
                {
                    UUID, new PostgresTypeDescriptor(UUID, typeof(Guid))
                },
                {
                    BOOLEAN, new PostgresTypeDescriptor(BOOLEAN, typeof(bool))
                },
            };
        }
    }
}
