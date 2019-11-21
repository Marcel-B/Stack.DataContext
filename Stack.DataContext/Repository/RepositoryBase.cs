using com.b_velop.stack.DataContext.Abstract;
using com.b_velop.stack.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace com.b_velop.stack.DataContext.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntity
    {
        protected MeasureContext Db;
        private readonly ILogger<RepositoryBase<T>> _logger;

        public RepositoryBase(
            MeasureContext db,
            ILogger<RepositoryBase<T>> logger)
        {
            Db = db;
            _logger = logger;
        }
        public async Task<IEnumerable<T>> SelectAllAsync()
          => await Db.Set<T>().ToListAsync();

        public async Task<T> SelectByIdAsync(
            Guid id)
            => await Db.Set<T>().FirstOrDefaultAsync(_ => _.Id == id);

        public async Task<IEnumerable<T>> SelectByConditionAsync(Expression<Func<T, bool>> expression)
            => await Db.Set<T>().Where(expression).ToListAsync();

        public async Task<T> InsertAsync(
            T entity)
        {
            var result = await Db.Set<T>().AddAsync(entity);
            _ = Db.SaveChanges();
            return result.Entity;
        }

        public T Update(
            T entity)
        {
            var result = Db.Set<T>().Update(entity);
            _ = Db.SaveChanges();
            return result.Entity;
        }

        public IEnumerable<T> UpdateBunch(
            IEnumerable<T> entities)
        {
            Db.Set<T>().UpdateRange(entities.ToArray());
            _ = Db.SaveChanges();
            return entities;
        }

        public async Task<IEnumerable<T>> InsertBunchAsync(
            IEnumerable<T> entities)
        {
            await Db.Set<T>().AddRangeAsync(entities);
            _ = Db.SaveChanges();
            return entities;
        }
    }
}
