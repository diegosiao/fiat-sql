using System.Collections.Generic;

namespace Slink
{
    public class SlinkQueryResult<T>
    {
        public bool HasMore { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
