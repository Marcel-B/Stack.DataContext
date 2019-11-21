using com.b_velop.stack.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace com.b_velop.stack.DataContext.Repository
{
    public interface IRepositoryBase<T> where T : class, IEntity
    {
        Task<T> InsertAsync(T entity);
        Task<IEnumerable<T>> SelectAllAsync();
        Task<IEnumerable<T>> SelectByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T> SelectByIdAsync(Guid id);
        T Update(T entity);
        IEnumerable<T> UpdateBunch(IEnumerable<T> entities);
        Task<IEnumerable<T>> InserBunchAsync(IEnumerable<T> entities);
    }
}
