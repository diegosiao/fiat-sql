using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FiatSql
{
    public abstract class FiatSqlQuery<T>
    {
        /// <summary>
        /// This is a protected method to ensure the origin of procedure compilations.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        protected static FiatSqlFilterBuilder<T> Where(Expression<Func<T, object>> expression)
        {
            var filterBuilder = new FiatSqlFilterBuilder<T>(expression);
            return filterBuilder;
        }
    }

    public class FiatSqlFilterBuilder<T>
    {
        private readonly List<Expression<Func<T, object>>> expressions;

        private readonly List<MemberExpression> orderByAscExpressions;

        private readonly List<MemberExpression> orderByDescExpressions;

        internal FiatSqlFilterBuilder(Expression<Func<T, object>> expression)
        {
            expressions = new List<Expression<Func<T, object>>>
            {
                expression
            };
            orderByAscExpressions = new List<MemberExpression>();
            orderByDescExpressions = new List<MemberExpression>();
        }

        public FiatSqlFilterBuilder<T> And(Expression<Func<T, object>> expression)
        {
            expressions.Add(expression);
            return this;
        }

        public FiatSqlFilterBuilder<T> OrderByDesc(params Expression<Func<T, object>>[] properties)
        {
            foreach (var property in properties)
                orderByAscExpressions.Add(property.Body as MemberExpression);

            return this;
        }

        public FiatSqlFilterBuilder<T> OrderByAsc(params Expression<Func<T, object>>[] properties)
        {
            foreach (var property in properties)
            {
                if(property.Body is MemberExpression)
                {
                    orderByAscExpressions.Add(property.Body as MemberExpression);
                }
                else if (property.Body is UnaryExpression)
                {
                    orderByAscExpressions.Add(((UnaryExpression)property.Body).Operand as MemberExpression);
                }
            }

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSize">The limit of registries to be loaded. Note that specyfing null will remove the limit.</param>
        /// <param name="pageNumber">The page number of registries</param>
        /// <param name="cacheTimeSpan"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<FiatSqlQueryResult<T>> Exec(uint? pageSize = 1, uint? pageNumber = 1, long cacheTimeSpan = 0)
        {
            var stringBuilder = new StringBuilder();

            var whereClause = expressions.FirstOrDefault();

            if (whereClause != null)
            {
                // Where clause
                var operand = ((UnaryExpression)whereClause.Body).Operand as BinaryExpression;
                var leftExpression = ((MemberExpression)operand.Left).Member;
                var rightExpression = ((ConstantExpression)operand.Right).Value;

                stringBuilder.AppendLine($"WHERE {leftExpression.DeclaringType.FullName}.{leftExpression.Name} {operand.NodeType} {rightExpression}");

                // Ands
                foreach (var and in expressions.Skip(1))
                {
                    if (((UnaryExpression)and.Body).Operand is not BinaryExpression)
                        continue;

                    operand = ((UnaryExpression)and.Body).Operand as BinaryExpression;
                    leftExpression = ((MemberExpression)operand.Left).Member;

                    rightExpression = null;

                    // can be a property
                    if (operand.Right is MemberExpression)
                    {
                        rightExpression = ((MemberExpression)operand.Right).Member.Name;
                    }
                    // variable (field)
                    else if (operand.Right is ConstantExpression) 
                    {
                        rightExpression = ((ConstantExpression)operand.Right).Value;
                    }
                    else
                        continue;

                    stringBuilder.AppendLine($"AND {leftExpression.DeclaringType.FullName}.{leftExpression.Name} {operand.NodeType} {rightExpression}");
                }
            }

            // Order by
            if (orderByAscExpressions.Any())
            {
                stringBuilder.Append("ORDER BY ");
                stringBuilder.Append(string.Join(", ", orderByAscExpressions.Select(x => $"{x} ASC")));
            }

            Debug.WriteLine(stringBuilder.ToString());

            return await Task.FromResult(default(FiatSqlQueryResult<T>));
        }
    }
}
