using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class 
    {
        
        T Get(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T,bool>> predicate);

        void Add(T entity);
        void Remove(T entity);
    }
}
