using FiatSql.Cli.Entities;
using System.Collections.Generic;

namespace FiatSql.Cli.Queries
{
    public class Customers
    {
        public PersonEntity Person { get; set; }

        public IEnumerable<CarEntity> Cars { get; set; }
    }
}
