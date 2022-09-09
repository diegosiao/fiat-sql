using System;
using System.Collections.Generic;

namespace FiatSql.Vendors.MySql2
{
    internal class MySql2Writer : IFiatSqlWriter
    {
        public FiatSqlParseResult If(string sqlCondition)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> ProcedureParameters(IEnumerable<FiatDbParameter> parameters)
        {
            throw new NotImplementedException();
        }

        public FiatSqlParseResult SelectById<TEntity>(object id)
        {
            throw new NotImplementedException();
        }
    }
}
