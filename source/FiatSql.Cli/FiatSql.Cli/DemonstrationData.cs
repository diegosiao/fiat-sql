using FiatSql.Cli.Entities;
using System;

namespace FiatSql.Cli
{
    internal static class DemonstrationData
    {
        public static PersonEntity PersonA = new PersonEntity
        {
            Id = Guid.NewGuid(),
            Name = "John Smith Addams",
            Birth = new DateTime(1980, 10, 10, 0, 0, 0, DateTimeKind.Utc),
            Salary = 15488.55M,
            IsPremium = true,
            Creation = DateTime.UtcNow
        };

        public static PersonEntity PersonB = new PersonEntity
        {
            Id = Guid.NewGuid(),
            Name = "Robert Murdock",
            Birth = new DateTime(1975, 7, 15, 0, 0, 0, DateTimeKind.Utc),
            Salary = 105255.35M,
            IsPremium = false,
            Creation = DateTime.UtcNow
        };

        public static PersonEntity PersonC = new PersonEntity
        {
            Id = Guid.NewGuid(),
            Name = "Anna Smith",
            Birth = new DateTime(1985, 2, 12, 0, 0, 0, DateTimeKind.Utc),
            Salary = 15488.55M,
            IsPremium = true,
            Creation = DateTime.UtcNow
        };

        public static PersonEntity PersonD = new PersonEntity
        {
            Id = Guid.NewGuid(),
            Name = "John Smith Addams",
            Birth = new DateTime(1980, 10, 10, 0, 0, 0, DateTimeKind.Utc),
            Salary = 15488.55M,
            IsPremium = true,
            Creation = DateTime.UtcNow
        };

        public static CarEntity CarA = new CarEntity
        {
            Id = Guid.NewGuid(),
            Model = "GM Camaro",
            ModelYear = 2016,
            Plates = "CA4786DM",
            Creation = DateTime.UtcNow
        };

        public static PersonCarRelationEntity PersonCarRelationA = new PersonCarRelationEntity
        {
            Id = Guid.NewGuid(),
            PersonId = PersonA.Id,
            CarId = CarA.Id,
            Creation = DateTime.UtcNow
        };
    }
}
