using com.b_velop.stack.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.b_velop.stack.DataContext.Repository
{

    public interface IDataStore<TType> where TType : IEntity
    {
        Task<TType> SaveAsync(TType value);
        Task<TType> UpdateAsync(Guid id, TType value);
        Task<TType> DeleteAsync(TType value);
        Task<TType> DeleteAsync(Guid id);
        Task<IEnumerable<TType>> GetAllAsync();
        Task<int> SaveBulkAsync(TType[] values);
    }
}
