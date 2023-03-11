using Helix.Common.Configuration;
using Helix.Core;
using Helix.Example.Persistence;
using Newtonsoft.Json;

namespace Helix.Example.Cli
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, world!");

            var configFile = Path.Join(AppContext.BaseDirectory, @"..\..\..\..\Helix.Example.Persistence", "helix.config.json");

            var configuration = JsonConvert.DeserializeObject<GlobalConfiguration>(File.ReadAllText(configFile));

            var person = new person()
            {
                id = Guid.NewGuid(),
                name = "Test",
                ispremium = true,
                salary = 56647.655M,
                createdby = "Me",
                creation = DateTime.Now
            };

            var helix = new HelixExecute(configuration?.Databases[0] ?? new DatabaseConfiguration());
            var id = await helix.InsertAsync(person);

            Console.WriteLine($"Person inserted with id: '{id}'");

            Console.WriteLine("Press any key to terminate...");
            Console.ReadKey();
        }
    }
}