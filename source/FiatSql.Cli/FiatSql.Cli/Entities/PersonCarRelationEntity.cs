using Slink.Mapping;
using System;
using System.ComponentModel.DataAnnotations;

namespace Slink.Cli.Entities
{
    /// <summary>
    /// Class to demonstrate how to handle One to Many relations
    /// </summary>
    [FiatTable("personcars", "id")]
    public class PersonCarRelationEntity : EntityBase<PersonCarRelationEntity>
    {
        public Guid CarId { get; set; }

        public Guid PersonId { get; set; }

        [MaxLength(250)]
        public string Info { get; set; }
    }
}
