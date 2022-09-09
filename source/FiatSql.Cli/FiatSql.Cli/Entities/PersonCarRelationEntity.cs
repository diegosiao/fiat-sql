using FiatSql.Mapping;
using System;

namespace FiatSql.Cli.Entities
{
    [FiatTable("personcars", "id")]
    public class PersonCarRelationEntity : EntityBase<PersonCarRelationEntity>
    {
        public Guid CarId { get; set; }

        public Guid PersonId { get; set; }
    }
}
