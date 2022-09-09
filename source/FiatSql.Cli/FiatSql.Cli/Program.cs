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
    /// <para>- Portability;</para>
    /// <para>- Efficienty first (not developer convenience first);</para>
    /// <para>- Testability;</para>
    /// <para>- CQRS oriented;</para>
    /// 
    /// Why not Linq?
    /// 
    /// <para>Linq is powerful. We all agree with that. But its complexity and size are overhelming in some scenarios.</para>
    /// <para>In the other hand, Slink uses Dapper under the hood and has an efficiency first approach while keeping portability as the most important premise.</para>
    /// 
    /// <a href="https://github.com/diegosiao/fiat-sql"/>
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
                SkipShemaValidation = false,
                SkipProcedureValidation = false,
            });

            var yesterdayAfternoon = DateTime.Today.AddHours(-11);
            var personQueryResult = await PersonQuery.WithValidatedAdresses(yesterdayAfternoon);

            foreach(var item in personQueryResult.Items ?? Array.Empty<PersonQuery>())
            {
                Console.WriteLine(item.Person.Name);
            }

            PersonEntity person = new()
            {
                Id = Guid.NewGuid(),
                Name = "John Smith Addams",
                Birth = new DateTime(1980, 10, 10, 0, 0, 0, DateTimeKind.Utc),
                Salary = 15488.55M,
                IsPremium = true,
                Creation = DateTime.UtcNow
            };

            CarEntity car = new()
            {
                Id = Guid.NewGuid(),
                Model = "GM Camaro",
                ModelYear = 2016,
                Plates = "CA4786DM",
                Creation = DateTime.UtcNow
            };

            PersonCarRelationEntity personCarRelation = new()
            {
                Id = Guid.NewGuid(),
                PersonId = person.Id,
                CarId = car.Id,
                Creation = DateTime.UtcNow
            };

            var command = new CustomerCreateCommand(person, car, personCarRelation);
            Debug.WriteLine(command.BuildSql());

            command.Call();

            var personEntity = await PersonEntity.GetByIdAsync(person.Id);
            personEntity.Birth = new DateTime(1995, 01, 01);

            await PersonEntity.UpsertAsync(personEntity);

            Console.WriteLine(command.Error?.ToString() ?? $"{nameof(CustomerCreateCommand)} executed successfully");
        }
    }
}
