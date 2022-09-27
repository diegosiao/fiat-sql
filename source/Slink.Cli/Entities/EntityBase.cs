using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Slink.Cli.Entities
{
    /// <summary>
    /// Your entity classes need to inherit from SlinkEntity&lt;<typeparamref name="T"/>&gt;
    /// <para>The Id property is required.</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class EntityBase<T> : SlinkEntity<T>
    {
        [Key]
        public Guid Id { get; set; }

        [ReadOnly(true)]
        public DateTime Creation { get; set; }

        [ReadOnly(true)]
        public string CreatedBy { get; set; }

        public DateTime? LastUpdate { get; set; }

        public string LastUpdatedBy { get; set; }
    }
}
