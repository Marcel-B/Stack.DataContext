using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.b_velop.stack.DataContext.Abstract;
using com.b_velop.stack.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace com.b_velop.stack.DataContext.Repository
{
    public class UnitRepository : IDataStore<Unit>
    {
        private readonly ILogger<UnitRepository> _logger;
        private readonly MeasureContext _context;

        public UnitRepository(
            MeasureContext context,
            ILogger<UnitRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> GetAsync(Guid id)
        {
            try
            {
                var current = await _context.Units.FirstOrDefaultAsync(x => x.Id == id);
                return current;

            }
            catch (Exception ex)
            {
                _logger.LogError(2831, ex, $"Error occurred while getting '{id}'.", id);
                return null;
            }
        }

        public async Task<Unit> SaveAsync(Unit value)
        {
            try
            {
                var result = await _context.AddAsync(value);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(2832, ex, $"Error occurred while inserting '{value.Id}'.", value);
                return null;
            }
        }

        public async Task<Unit> UpdateAsync(Guid id, Unit value)
        {
            try
            {
                var current = await _context.Units.FirstOrDefaultAsync(x => x.Id == id);
                _context.Entry(current).State = EntityState.Modified;
                current.Display = value.Display;
                current.Name = value.Name;
                await _context.SaveChangesAsync();
                return current;
            }
            catch (Exception ex)
            {
                _logger.LogError(2834, ex, $"Error occurred while updating '{id}'.", id, value);
                return null;
            }
        }

        public async Task<Unit> DeleteAsync(Unit value)
            => await DeleteAsync(value.Id);

        public async Task<Unit> DeleteAsync(Guid id)
        {
            try
            {
                var current = await _context.Units.FirstOrDefaultAsync(x => x.Id == id);
                _context.Units.Remove(current);
                await _context.SaveChangesAsync();
                return current;
            }
            catch (Exception ex)
            {
                _logger.LogError(2833, ex, $"Error occurred while deleting '{id}'.", id);
                return null;
            }
        }

        public async Task<IEnumerable<Unit>> GetAllAsync()
            => await _context.Units.ToListAsync();

        public async Task<int> SaveBulkAsync(Unit[] values)
        {
            try
            {
                await _context.Units.AddRangeAsync(values);
                var result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(2835, ex, $"Error occurred while inserting bulk.", values);
                return -1;
            }
        }
    }
}