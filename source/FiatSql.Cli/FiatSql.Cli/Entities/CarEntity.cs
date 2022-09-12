using Slink.Mapping;

namespace Slink.Cli.Entities
{
    /// <summary>
    /// Class to demonstrate One to Many relation with Person
    /// </summary>
    [FiatTable("car", "id", 10)]
    public class CarEntity : EntityBase<CarEntity>
    {
        public string Model { get; set; }

        public int ModelYear { get; set; }

        public string Plates { get; set; }
    }
}
