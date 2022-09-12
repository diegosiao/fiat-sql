using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Slink
{
    public class SlinkWhere<TSource>
    {
        public SlinkWhere(Expression<Func<TSource, object>> expression)
        {
            Debug.WriteLine(expression.Parameters[0].Type.FullName);

        }

        public SlinkWhere(UnaryExpression expression)
        {

        }
    }
}
