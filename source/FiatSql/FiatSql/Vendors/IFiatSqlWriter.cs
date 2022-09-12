using System.Collections.Generic;

namespace Slink.Vendors
{
    public interface IFiatSqlWriter
    {
        SlinkParseResult If(string sqlCondition);

        SlinkParseResult SelectById<TEntity>(object id);

        IEnumerable<string> ProcedureParameters(IEnumerable<FiatDbParameter> parameters);
    }
}
