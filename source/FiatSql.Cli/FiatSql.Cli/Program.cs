using Slink.Cli.Entities;
using Slink.Cli.Commands;
using Slink.Cli.Queries;
using Npgsql;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Slink.Cli
{
    /// <summary>
    /// [Slink] or [FiatSql]
    /// <para>Turn C# code into translated SQL procedures that can run in all supported databases out of the box.</para>
    /// <para><a href="https://github.com/diegosiao/fiat-sql"/></para>
    /// </summary>
    class Program
    {
        static async Task Main(string[] args)
        {
            Slink.Init(new SlinkConfigOptions
            {
                Vendor = FiatSqlVendors.Postgres,
                ConnectionFactory = () => new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgres"].ConnectionString),
                EntitiesNamespaces = new[] { typeof(AddressEntity).Namespace },
                ProceduresNamespaces = new[] { typeof(CustomerCreateCommand).Namespace },
                StoredProceduresOnly = true,
                SkipShemaValidation = false,
                SkipProcedureValidation = false,
            });

            // 1. Entity CRUD database operations, sync and async

            // Note: CRUD methods have instance and static versions

            // 1.1. Create
            DemonstrationData.JohnSmith.Insert();
            await DemonstrationData.RobertMurdock.InsertAsync();

            // 1.2. Read
            var dbPersonA = PersonEntity.GetById(DemonstrationData.JohnSmith.Id);
            var dbPersonB = await PersonEntity.GetByIdAsync(DemonstrationData.RobertMurdock.Id);

            var personsA = PersonEntity.GetAll();
            var personsB = await PersonEntity.GetAllAsync();

            // 1.3. Update
            DemonstrationData.AnnaSmith.Upsert();
            await DemonstrationData.AnnaSmith.UpsertAsync();

            // TODO Make it happen
            //await PersonEntity
            //    .Update(DemonstrationData.PersonE)
            //    .Set(x => x.Birth, new DateTime(1981, 10, 10))
            //    .Set(x => x.Salary, 21851M)
            //    .Where(x => x.Id != null)
            //    .And(x => x.Birth > new DateTime(1980, 01, 01))
            //    .ExecAsync(exceptionIfNotFound: false);

            // 1.4. Delete
            DemonstrationData.AnnaSmith.Delete();
            await DemonstrationData.ClaireLoughhead.DeleteAsync();

            //PersonEntity.DeleteById();
            //PersonEntity.DeleteAllById();

            // 2. Where Slink shines the most: Stored Procedures for Commands and Queries

            // 2.1. Command
            var command = new CustomerCreateCommand(
                DemonstrationData.JohnSmith, 
                DemonstrationData.JohnSmithCar, 
                DemonstrationData.PersonCarRelationA);

            Debug.WriteLine(command.BuildSql());

            command.Call();

            Console.WriteLine(command.Error?.ToString() ?? $"{nameof(CustomerCreateCommand)} executed successfully");

            // 2.2. Query
            var queryResult = await PersonQuery.WithValidatedAdressesAsync(DateTime.Now.AddDays(-1));

            foreach(var item in queryResult.Items)
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
