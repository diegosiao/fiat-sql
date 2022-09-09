using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace FiatSql
{
    public class FiatSqlWhere<TSource>
    {
        public FiatSqlWhere(Expression<Func<TSource, object>> expression)
        {
            Debug.WriteLine(expression.Parameters[0].Type.FullName);

        }

        public FiatSqlWhere(UnaryExpression expression)
        {

        }
    }
}
