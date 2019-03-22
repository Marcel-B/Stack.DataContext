using com.b_velop.stack.DataContext.Abstract;
using com.b_velop.stack.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.b_velop.stack.DataContext.Repository
{
    public class MeasureValueRepository : IDataStore<MeasureValue>
    {
        private MeasureContext _context;
        private ILogger<MeasureValueRepository> _logger;

        public MeasureValueRepository(
            ILogger<MeasureValueRepository> logger,
            MeasureContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<MeasureValue> DeleteAsync(MeasureValue value)
        {
            try
            {
                var result = await DeleteAsync(value.Id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(1111, ex, $"Error");
                return null;
            }
        }

        public async Task<MeasureValue> DeleteAsync(Guid id)
        {
            try
            {
                var current = await _context.MeasureValues.FirstOrDefaultAsync(x => x.Id == id);
                if (current == null)
                    return null;
                _context.MeasureValues.Remove(current);
                await _context.SaveChangesAsync();
                return current;
            }
            catch (Exception ex)
            {
                _logger.LogError(1111, ex, $"Error");
                return null;
            }
        }

        public async Task<IEnumerable<MeasureValue>> GetAllAsync()
            => await _context.MeasureValues.ToListAsync();

        public async Task<MeasureValue> SaveAsync(MeasureValue value)
        {
            try
            {
                var result = await _context.MeasureValues.AddAsync(value);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(1111, ex, $"Error");
                return null;
            }
        }

        public async Task<int> SaveBulkAsync(MeasureValue[] values)
        {
            try
            {
                await _context.MeasureValues.AddRangeAsync(values);
                var result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(1111, ex, $"Error");
                return -1;
            };
        }

        public async Task<MeasureValue> UpdateAsync(Guid id, MeasureValue value)
        {
            try
            {
                var current = await _context.MeasureValues.FirstOrDefaultAsync(x => x.Id == id);
                if (current == null)
                {
                    await _context.MeasureValues.AddAsync(value);
                    await _context.SaveChangesAsync();
                    return value;
                }
                _context.Entry(current).State = EntityState.Modified;
                current.Point = value.Point;
                current.Timestamp = value.Timestamp;
                current.Value = value.Value;
                var result = await _context.SaveChangesAsync();
                return current;
            }
            catch (Exception ex)
            {
                _logger.LogError(1111, ex, $"Error");
                return null;
            }
        }
    }
}
