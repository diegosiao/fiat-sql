
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace FiatSql.Vendors
{
    public interface IFiatSqlWriter
    {
        FiatSqlParseResult If(string sqlCondition);

        IEnumerable<string> ProcedureParameters(IEnumerable<FiatDbParameter> parameters);
    }
}
