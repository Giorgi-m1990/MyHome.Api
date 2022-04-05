using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstraction
{
    public interface IRepository<T>
    {
        Task Create(T input);
        void Update(T input);
        void Delete(T input);
        Task<IEnumerable<T>> GetCollectionAsync(Expression<Func<T, bool>> expression = null);
        IQueryable<T> GetQueries(Expression<Func<T, bool>> expression = null);
        Task<bool> SaveChangesAsync();
    }
}
