using System;

namespace FiatSql.Cli.Entities
{
    public abstract class EntityBase<T> : FiatSqlEntity<T>
    {
        public Guid Id { get; set; }

        public DateTime Creation { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastUpdate { get; set; }

        public string LastUpdatedBy { get; set; }
    }
}
