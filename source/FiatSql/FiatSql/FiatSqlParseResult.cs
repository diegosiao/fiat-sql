using System.Collections.Generic;

namespace Slink
{
    public class SlinkParseResult
    {
        public string Sql { get; set; }

        public IEnumerable<FiatDbParameter> Params { get; set; }
    }
}
