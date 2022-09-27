using System.Collections.Generic;
using System.Text;

namespace Slink
{
    public enum SlinkCrudOperation 
    { 
        Insert,
        Update,
        Upsert,
        GetById,
        Delete,
    }

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
