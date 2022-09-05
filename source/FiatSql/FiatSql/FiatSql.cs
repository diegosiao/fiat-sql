using System;
using System.Diagnostics;

namespace FiatSql
{
    public static class FiatSql
    {
        static internal FiatSqlConfigOptions Options { get; private set; }

        public static void Init(FiatSqlConfigOptions options)
        {
            Options = options;

            ValidateDatabase();
        }

        public static void ValidateDatabase()
        {
            Debug.WriteLine("Mapping database...");

            Debug.WriteLine("Validating entities...");

            Debug.WriteLine("Validating schemas and procedures hashes...");


        }
    }
}
