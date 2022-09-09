using System.Collections.Generic;

namespace FiatSql
{
    public class FiatSqlParseResult
    {
        public string Sql { get; set; }

        public IEnumerable<FiatDbParameter> Params { get; set; }
    }
}
