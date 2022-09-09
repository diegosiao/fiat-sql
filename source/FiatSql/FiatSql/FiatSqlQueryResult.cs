using System.Collections.Generic;

namespace FiatSql
{
    public class FiatSqlQueryResult<T>
    {
        public bool HasMore { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
