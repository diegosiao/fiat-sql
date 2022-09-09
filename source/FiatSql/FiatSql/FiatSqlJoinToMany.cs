using System;

namespace FiatSql
{
    public class FiatSqlJoinToManyAttribute : Attribute
    {
        public FiatSqlJoinToManyAttribute(Type relationEntity, string fromColumn, string onColumn, bool leftJoin = false)
        {

        }
    }
}
