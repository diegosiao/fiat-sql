using FiatSql.Cli.Entities;
using FiatSql.Cli.Commands;
using FiatSql.Cli.Queries;
using Npgsql;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FiatSql.Cli
{
    /// <summary>
    /// [Slink]
    /// <para>Turn C# code into translated SQL procedures that can run in all supported databases out of the box.</para>
    /// <para><a href="https://github.com/diegosiao/fiat-sql"/></para>
    /// </summary>
    class Program
    {
        static async Task Main(string[] args)
        {
            FiatSql.Init(new FiatSqlConfigOptions
            {
                Vendor = FiatSqlVendors.Postgres,
                ConnectionFactory = () => new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgres"].ConnectionString),
                EntitiesNamespaces = new[] { typeof(AddressEntity).Namespace },
                ProceduresNamespaces = new[] { typeof(CustomerCreateCommand).Namespace },
                StoredProceduresOnly = true,
                SkipShemaValidation = false,
                SkipProcedureValidation = false,
            });

            // [1] ALL CRUD operations, sync and async
            PersonEntity.Insert(DemonstrationData.PersonA);
            await PersonEntity.InsertAsync(DemonstrationData.PersonB);
                        
            var dbPersonA = PersonEntity.GetById(DemonstrationData.PersonA.Id);
            var dbPersonB = await PersonEntity.GetByIdAsync(DemonstrationData.PersonB.Id);

            PersonEntity.Upsert(DemonstrationData.PersonC);
            await PersonEntity.UpsertAsync(DemonstrationData.PersonD);

            // TODO Make it happen
            //PersonEntity
            //    .Update()
            //    .Set(x => x.Birth, new DateTime(1981, 10, 10))
            //    .Set(x => x.Salary, 21851M)
            //    .Exec();

            PersonEntity.Delete(DemonstrationData.PersonA.Id);
            await PersonEntity.DeleteAsync(DemonstrationData.PersonB.Id);

            // Where it shines the most: Stored Procedures for Commands and Queries
            // Command
            var command = new CustomerCreateCommand(
                DemonstrationData.PersonA, 
                DemonstrationData.CarA, 
                DemonstrationData.PersonCarRelationA);

            Debug.WriteLine(command.BuildSql());

            command.Call();

            Console.WriteLine(command.Error?.ToString() ?? $"{nameof(CustomerCreateCommand)} executed successfully");

            // Query
            var query = PersonQuery.WithValidatedAdressesAsync(DateTime.Now.AddDays(-1));

            foreach(var item in query.Result.Items)
            {
                Console.WriteLine(item.Person.Name);
            }

            Console.WriteLine("Slink demonstration executed successfully. Neat, isn't?");
            Console.WriteLine("\n\nThank you for downloading and using Slink. Have fun! ;)");
        }
    }
}
