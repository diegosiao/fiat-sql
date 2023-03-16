using Helix.Common;
using Helix.Engine.Configuration;
using Helix.Engine.Metadata.Postgres;
using Newtonsoft.Json;

namespace Helix.Engine
{
    internal static class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0 || !File.Exists(args[0]))
            {
                Console.WriteLine("You need to inform the 'helix.config.json' file location as first argument. ");
                return 1;
            }

            Console.WriteLine("Helix task 1 of 4: Loading configuration and validating configuration...");

            var configFile = Path.Join(args[0]);

            var configuration = JsonConvert.DeserializeObject<GlobalConfiguration>(File.ReadAllText(configFile));

            if (!configuration?.Validate() ?? true)
            {
                Console.Write("Error loading configuration.");
                return -1;
            }

            Console.Write("Done successfully.");

            var tasks = new List<Task>();
            foreach (var item in configuration.Databases)
            {
                item.BaseDirectory = Path.GetDirectoryName(configFile) ?? AppContext.BaseDirectory;
                var metadataProvider = new PostgresMetadataProvider(item);
                tasks.Add(metadataProvider.LoadDescriptorsAsync());
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Helix done its tasks in 3,3min.");

            return 0;
        }
    }
}