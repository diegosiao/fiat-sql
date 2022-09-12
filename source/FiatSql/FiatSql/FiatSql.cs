using System;
using System.Diagnostics;

namespace Slink
{
    public static class Slink
    {
        static internal SlinkConfigOptions Options { get; private set; }

        public static void Init(SlinkConfigOptions options)
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
