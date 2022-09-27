using System.Collections.Generic;
using System.Text;

namespace Slink
{
    public class SlinkParseResult
    {
        public StringBuilder Sql { get; set; }

        public List<FiatDbParameter> Params { get; set; }

        public SlinkParseResult()
        {
            Sql = new StringBuilder();
            Params = new List<FiatDbParameter>();
        }
    }
}
