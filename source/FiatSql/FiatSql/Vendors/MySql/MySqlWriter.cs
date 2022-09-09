using System;
using System.Collections.Generic;

namespace FiatSql.Vendors.MySql
{
    internal class MySqlWriter : IFiatSqlWriter
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
