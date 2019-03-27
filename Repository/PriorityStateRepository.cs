using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.b_velop.stack.DataContext.Entities;
using com.b_velop.stack.DataContext.Abstract;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
namespace com.b_velop.stack.DataContext.Repository
{
    public class PriorityStateRepository : IDataStore<PriorityState>
    {
        private readonly MeasureContext _context;
        private readonly ILogger<PriorityStateRepository> _logger;

        public PriorityStateRepository(
            MeasureContext context,
            ILogger<PriorityStateRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<PriorityState> DeleteAsync(PriorityState value)
            => await DeleteAsync(value.Id);

        public async Task<PriorityState> DeleteAsync(Guid id)
        {
            try
            {
                var current = await _context.PriorityStates.FirstOrDefaultAsync(x => x.Id == id);
                _context.PriorityStates.Remove(current);
                await _context.SaveChangesAsync();
                return current;
            }
            catch (Exception ex)
            {
                _logger.LogError(2833, ex, $"Error occurred while deleting '{id}'", id);
                return null;
            }
        }

        public async Task<IEnumerable<PriorityState>> GetAllAsync()
            => await _context.PriorityStates.ToListAsync();

        public async Task<PriorityState> GetAsync(Guid id)
        {
            try
            {
                var current = await _context.PriorityStates.FirstOrDefaultAsync(x => x.Id == id);
                return current;
            }
            catch (Exception ex)
            {
                _logger.LogError(2831, ex, $"Error occurred while getting '{id}'.", id);
                return null;
            }
        }

        public async Task<PriorityState> SaveAsync(PriorityState value)
        {
            try
            {
                var result = await _context.PriorityStates.AddAsync(value);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(2832, ex, $"Error occurred while inserting '{value.Id}'.", value);
                return null;
            }
        }

        public async Task<int> SaveBulkAsync(PriorityState[] values)
        {
            try
            {
               await _context.PriorityStates.AddRangeAsync(values);
                var result = await _context.SaveChangesAsync();
                return result; 
            }
            catch (Exception ex)
            {
                _logger.LogError(2835, ex, $"Error occurred while inserting bulk.", values);
                return -1;
            }
        }

        public async Task<PriorityState> UpdateAsync(Guid id, PriorityState value)
        {
            try
            {
                var current = await _context.PriorityStates.FirstOrDefaultAsync(x => x.Id == id);
                _context.Entry(current).State = EntityState.Modified;
                current.Point = value.Point;
                current.State = value.State;
                current.Timestamp = value.Timestamp;
                await _context.SaveChangesAsync();
                return current;
            }
            catch (Exception ex)
            {
                _logger.LogError(2834, ex, $"Error occurred while updating '{id}'.", id, value);
                return null;
            }
        }
    }
}
