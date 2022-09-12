using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slink
{
    public class FiatUpsert<TEntity> : FiatCrudOperation<TEntity>
    {
        public FiatUpsert(TEntity entity) : base(entity)
        {
            
        }
    }
}
