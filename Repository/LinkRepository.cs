using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.b_velop.stack.DataContext.Entities;
using Microsoft.Extensions.Logging;
using com.b_velop.stack.DataContext.Abstract;
using Microsoft.EntityFrameworkCore;

namespace com.b_velop.stack.DataContext.Repository
{
    public class LinkRepository : IDataStore<Link>
    {
        private readonly ILogger<LinkRepository> _logger;
        private readonly MeasureContext _measureContext;

        public LinkRepository(
            MeasureContext measureContext,
            ILogger<LinkRepository> logger)
        {
            _logger = logger;
            _measureContext = measureContext;
        }

        public async Task<Link> SaveAsync(
           Link value)
        {
            try
            {
                var result = await _measureContext.Links.AddAsync(value);
                await _measureContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(2832, ex, $"Error occurred while inserting '{value}'", value);
                return null;
            }
        }

        public async Task<Link> UpdateAsync(
            Guid id,
            Link value)
        {
            try
            {
                var current = await _measureContext.Links.FirstOrDefaultAsync(x => x.Id == id);
                _measureContext.Entry(current).State = EntityState.Modified;
                current.LinkValue = value.LinkValue;
                current.Name = value.Name;
                current.LastEdit = DateTimeOffset.Now;
                await _measureContext.SaveChangesAsync();
                return current;
            }
            catch (Exception ex)
            {
                _logger.LogError(2834, ex, $"Error occurred while updating '{id}'", id, value);
                return null;
            }
        }

        public async Task<Link> DeleteAsync(
            Link value)
            => await DeleteAsync(value.Id);

        public async Task<Link> DeleteAsync(
            Guid id)
        {
            try
            {
                var tmp = await _measureContext.Links.FirstOrDefaultAsync(x => x.Id == id);
                _measureContext.Links.Remove(tmp);
                await _measureContext.SaveChangesAsync();
                return tmp;
            }
            catch (Exception ex)
            {
                _logger.LogError(2833, ex, $"Error occurred while deleting '{id}'.", id);
                return null;
            }
        }

        public async Task<IEnumerable<Link>> GetAllAsync()
            => await _measureContext.Links.ToListAsync();

        public async Task<int> SaveBulkAsync(
            Link[] values)
        {
            try
            {
                await _measureContext.Links.AddRangeAsync(values);
                var result = await _measureContext.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(2835, ex, $"Error occurred while inserting bulk.", values);
                return -1;
            }
        }

        public async Task<Link> GetAsync(Guid id)
        {
            try
            {
                var current = await _measureContext.Links.FirstOrDefaultAsync(x => x.Id == id);
                return current;
            }
            catch (Exception ex)
            {
                _logger.LogError(2831, ex, $"Error occurred while getting '{id}'.", id);
                return null;
            }
        }
    }
}