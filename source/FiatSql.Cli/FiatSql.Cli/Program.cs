using MySql.Data.MySqlClient;
using Npgsql;
using Slink.Cli.Commands;
using Slink.Cli.Entities;
using Slink.Cli.Queries;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Slink.Cli
{
    /// <summary>
    /// [Slink]
    /// <para>Turn C# classes into translated SQL Stored Procedures and run your application against any supported databases out of the box.</para>
    /// <para><a href="https://github.com/diegosiao/fiat-sql"/></para>
    /// </summary>
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("* * * * * * * * * * * * * * *");
            Console.WriteLine("* *   S   L   I   N   K   * *");
            Console.WriteLine("* * * * * * * * * * * * * * *");

            // 🎉 Same C# code no matter what database.
            var slinkOptions = new SlinkConfigOptions();

            if ("mysql".Equals(args.FirstOrDefault()))
            {
                slinkOptions.AddNamespaces(
                    namespaces: new Type[] { typeof(PersonEntity) },
                    vendor: SlinkVendors.MySQL,
                    databaseSchema: "slink",
                    connectionFactory: () => new MySqlConnection(
                        ConfigurationManager.ConnectionStrings["mysql"].ConnectionString));
            }
            else
            {
                slinkOptions.AddNamespaces(
                    namespaces: new Type[] { typeof(PersonEntity) },
                    databaseSchema: "public",
                    vendor: SlinkVendors.Postgres,
                    connectionFactory: () => new NpgsqlConnection(
                        ConfigurationManager.ConnectionStrings["postgres"].ConnectionString));
            }

            Slink.Init(slinkOptions);

            Console.WriteLine($"{Slink.ConfigFor<PersonEntity>().Vendor} vendor database selected. Valid arguments are: mysql and postgres");

            // 1. Entity CRUD database operations, sync and async

            Console.WriteLine(" - Note: CRUD methods have instance and static versions");

            // 1.1. Create
            StaticData.JohnSmith.Insert();
            await StaticData.RobertMurdock.InsertAsync();

            StaticData.JohnSmith.Upsert();
            await StaticData.JohnSmith.UpsertAsync();

            // 1.2. Read
            var dbPersonA = PersonEntity.GetById(StaticData.JohnSmith.Id);
            var dbPersonB = await PersonEntity.GetByIdAsync(StaticData.RobertMurdock.Id);

            var personsA = PersonEntity.GetAll();
            var personsB = await PersonEntity.GetAllAsync();

            // 1.3. Update
            StaticData.AnnaSmith.Update();
            await StaticData.AnnaSmith.UpdateAsync();

            // 1.4. Delete
            StaticData.AnnaSmith.Delete();
            await StaticData.ClaireLoughhead.DeleteAsync();

            // 2. Slink shines the most: Stored Procedures for Commands and Queries for decoupling applications

            // 2.1. Command
            var command = new CustomerCreateCommand(
                StaticData.JohnSmith,
                StaticData.JohnSmithCar,
                StaticData.PersonCarRelationA);

            Debug.WriteLine(command.BuildSql());

            command.Call();

            Console.WriteLine(command.Error?.ToString() ?? $"{nameof(CustomerCreateCommand)} executed successfully");

            // 2.2. Query
            var queryResult = await PersonQuery.WithValidatedAdressesAsync(DateTime.Now.AddDays(-1));

            foreach (var item in queryResult.Items)
            {
                Console.WriteLine(item.Person.Name);
            }

            // 3. Reports

            // 3.1. Surface report

            // TODO Surface report (adoption, revision and fixes support)

            // 3.2. Portability report

            // TODO Portability report

            Console.WriteLine("Slink demonstration executed successfully. Neat, isn't?");
            Console.WriteLine("\n\nThank you for downloading and using Slink. Have fun! ;)");
        }
    }
}
