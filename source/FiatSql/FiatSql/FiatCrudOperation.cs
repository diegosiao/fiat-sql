using Dapper;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace FiatSql
{
    public class FiatCrudOperation<TEntity>
    {
        public List<FiatDbParameter> Parameters { get; set; }

        public StringBuilder Sql { get; protected set; }

        public FiatCrudOperation(TEntity entity)
        {
            Parameters = new List<FiatDbParameter>();
            Sql = new StringBuilder();
        }
    }
}
