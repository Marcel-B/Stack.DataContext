using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.b_velop.stack.DataContext.Repository
{
    public interface ITimeDataStore<TType> where TType : ITimeEntity
    {
        Task<IEnumerable<TType>> FilterPointValuesByTimeAsync(Guid id, int seconds);
        Task<IEnumerable<TType>> FilterValuesByTimeAsync(int seconds);
    }
}