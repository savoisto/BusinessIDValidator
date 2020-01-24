using System;
using System.Collections.Generic;

namespace BusinessIdSpecification
{
    public class BusinessIdSpecification<TEntity> : ISpecification<TEntity> where TEntity : class, new()
    {
        public IEnumerable<string> ReasonsForDissatisfaction => throw new NotImplementedException();

        static void Main()
        {

        }

        public bool IsSatisfiedBy(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
