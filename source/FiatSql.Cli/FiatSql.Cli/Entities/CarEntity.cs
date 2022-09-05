using FiatSql.Mapping;

namespace FiatSql.Cli.Entities
{
    [FiatTable(Name = "car")]
    public class CarEntity : EntityBase<CarEntity>
    {
        public string Model { get; set; }

        public int ModelYear { get; set; }

        public string Plates { get; set; }
    }
}
