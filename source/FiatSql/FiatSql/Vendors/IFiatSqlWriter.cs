using System.Collections.Generic;

namespace FiatSql.Vendors
{
    public interface IFiatSqlWriter
    {
        FiatSqlParseResult If(string sqlCondition);

        FiatSqlParseResult SelectById<TEntity>(object id);

        IEnumerable<string> ProcedureParameters(IEnumerable<FiatDbParameter> parameters);
    }
}
