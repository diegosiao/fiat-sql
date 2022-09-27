using Slink.Cli.Entities;
using System;

namespace Slink.Cli
{
    internal static class StaticData
    {
        public static PersonEntity JohnSmith = new()
        {
            Id = Guid.NewGuid(),
            Name = "John Smith",
            Birth = new DateTime(1980, 10, 10, 0, 0, 0, DateTimeKind.Utc),
            Salary = 155388.55M,
            IsPremium = true,
            Creation = DateTime.UtcNow
        };

        public static PersonEntity RobertMurdock = new()
        {
            Id = Guid.NewGuid(),
            Name = "Robert Murdock",
            Birth = new DateTime(1975, 7, 15, 0, 0, 0, DateTimeKind.Utc),
            Salary = 105255.35M,
            IsPremium = false,
            Creation = DateTime.UtcNow
        };

        public static PersonEntity AnnaSmith = new()
        {
            Id = Guid.NewGuid(),
            Name = "Anna Smith",
            Birth = new DateTime(1985, 2, 12, 0, 0, 0, DateTimeKind.Utc),
            Salary = 15488.55M,
            IsPremium = true,
            Creation = DateTime.UtcNow
        };

        public static PersonEntity ClaireLoughhead = new()
        {
            Id = Guid.NewGuid(),
            Name = "Claire Loughhead",
            Birth = new DateTime(1980, 10, 10, 0, 0, 0, DateTimeKind.Utc),
            Salary = 210000M,
            IsPremium = true,
            Creation = DateTime.UtcNow
        };

        public static CarEntity JohnSmithCar = new CarEntity
        {
            Id = Guid.NewGuid(),
            Model = "GM Camaro",
            ModelYear = 2016,
            Plates = "CA4786DM",
            Creation = DateTime.UtcNow
        };

        public static PersonCarRelationEntity PersonCarRelationA = new()
        {
            Id = Guid.NewGuid(),
            PersonId = JohnSmith.Id,
            CarId = JohnSmithCar.Id,
            Info = "Some additional information regarding this relation",
            Creation = DateTime.UtcNow
        };
    }
}
