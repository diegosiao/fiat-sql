using Slink.Mapping;

namespace Slink.Cli.Entities
{
    /// <summary>
    /// Class to demonstrate One to One relation with Person
    /// </summary>
    [FiatTable("address", "id")]
    public class AddressEntity : EntityBase<AddressEntity>
    {
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public bool Validated { get; set; }

        public string ZipCode { get; set; }
    }
}
