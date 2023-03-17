using Helix.Common;

namespace Helix.Engine
{
    internal static class DataProviderDllManager
    {
        internal static bool LoadDatabaseVendors(params DatabaseVendor[] databaseVendor)
        {
            foreach (var vendor in databaseVendor.Distinct())
            {
                Console.WriteLine($"Loading {vendor} data provider. ");
                // Check if already exists locally and download if not
                // github.com/vendors/postgres/v1/lib/*.zip (lib + dependencies)


                // Unzip and load DLLs
                // Assembly.Load(File.ReadAllBytes(""))
            }

            return true;
        }
    }
}
