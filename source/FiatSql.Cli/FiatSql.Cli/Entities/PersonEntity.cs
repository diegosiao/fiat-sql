using FiatSql.Mapping;
using System;

namespace FiatSql.Cli.Entities
{
    [FiatTable("person", "id")]
    public class PersonEntity : EntityBase<PersonEntity>
    {
        public string Name { get; set; }

        public bool IsPremium { get; set; }

        public Guid HomeAddressId { get; set; }

        public Guid WorkAddressId { get; set; }

        public DateTime Birth { get; set; }

        public decimal Salary { get; set; }
    }
}
