using FiatSql.Cli.Entities;
using FiatSql.Cli.Procedures;
using System;
using System.Configuration;

namespace FiatSql.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            FiatSql.Init(new FiatSqlConfigOptions
            {
                Vendor = FiatSqlVendors.Postgres,
                EntitiesNamespaces = new[] { typeof(CarEntity).Namespace },
                ProcedureNamespaces = new[] { typeof(Sp_CustomerCreate).Namespace },
                ConnectionFactory = () => new Npgsql.NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgres"].ConnectionString)
            });

            //FiatSql.Init(new FiatSqlConfigOptions
            //{
            //    Vendor = FiatSqlVendors.MySQL,
            //    EntitiesNamespaces = new[] { typeof(CarEntity).Namespace },
            //    ProcedureNamespaces = new[] { typeof(Sp_CustomerCreate).Namespace },
            //    ConnectionFactory = () => new Npgsql.NpgsqlConnection(ConfigurationManager.ConnectionStrings["mysql"].ConnectionString)
            //});

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

            Sp_CustomerCreate procedure = new(person, car, personCarRelation);
            procedure.Call();

            var dbPerson = PersonEntity.GetById(person.Id);

            Console.WriteLine(procedure.Error?.ToString() ?? $"{nameof(Sp_CustomerCreate)} executed successfully");
        }
    }
}
