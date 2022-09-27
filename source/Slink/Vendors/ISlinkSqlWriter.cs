using System;
using System.Collections.Generic;

namespace Slink.Vendors
{
    public interface ISlinkSqlWriter
    {
        bool SupportsCreateOrReplace { get; }

        SlinkParseResult If(string sqlCondition);

        SlinkParseResult SelectById<TEntity>(object id);

        SlinkParseResult Insert(Type entityType, object entity = null);

        IEnumerable<string> ProcedureParameters(IEnumerable<FiatDbParameter> parameters);
    }
}
