using FiatSql.Mapping;

namespace FiatSql.Cli.Entities
{
    [FiatTable("address", "id")]
    public class AddressEntity : EntityBase<AddressEntity>
    {
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public bool Validated { get; set; }

        public string ZipCode { get; set; }
    }
}
