using Slink.Mapping;
using Slink.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Slink.Cli.Entities
{
    /// <summary>
    /// Class to demonstrate database operations and relations (<see cref="CarEntity"/> and <see cref="AddressEntity"/>)
    /// </summary>
    // [System.ComponentModel.DataAnnotations.Schema.Table()]
    [FiatTable("person", "id")]
    public class PersonEntity : EntityBase<PersonEntity>
    {
        [MaxLength(250)]
        public string Name { get; set; }

        public bool IsPremium { get; set; }

        [Required]
        public Guid HomeAddressId { get; set; }

        public Guid? WorkAddressId { get; set; }

        public DateTime? Birth { get; set; }

        [GreaterThan(0)]
        public decimal Salary { get; set; }
    }
}
