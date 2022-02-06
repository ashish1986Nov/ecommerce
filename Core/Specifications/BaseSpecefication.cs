using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecefication<T> : ISpecification<T>
    {
        public BaseSpecefication()
        { 
        
        
        }


        public BaseSpecefication(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }


        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } =
            new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected void AddIncludes(Expression<Func<T, object>>_expression)
        {

            Includes.Add(_expression);
        }

        protected void AddOrderBy(Expression<Func<T, Object>> orderbyExpression)
        {
            OrderBy = orderbyExpression;

        }

        protected void AddOrderByDesceding(Expression<Func<T, Object>> orderbyDescendingExpression)
        {
            OrderByDescending = orderbyDescendingExpression;

        }


        protected void ApplyPaging(   int skip , int take )
        {

            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        
        }
    }
}
