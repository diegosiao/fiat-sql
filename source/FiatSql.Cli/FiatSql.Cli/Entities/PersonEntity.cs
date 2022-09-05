using FiatSql.Mapping;
using System;

namespace FiatSql.Cli.Entities
{
    [FiatTable(Name = "person")]
    public class PersonEntity : EntityBase<PersonEntity>
    {
        public string Name { get; set; }

        public bool IsPremium { get; set; }

        public DateTime Birth { get; set; }

        public decimal Salary { get; set; }
    }
}
