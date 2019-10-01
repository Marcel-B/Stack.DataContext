using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.b_velop.stack.DataContext.Abstract;
using com.b_velop.stack.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace com.b_velop.stack.DataContext.Repository
{
    public class ActiveMeasurePointRepository : IDataStore<ActiveMeasurePoint>
    {
        private readonly MeasureContext _context;
        private readonly ILogger<ActiveMeasurePointRepository> _logger;

        public ActiveMeasurePointRepository(
            MeasureContext context,
            ILogger<ActiveMeasurePointRepository> logger)
        {
            _context = context;
            _logger = logger;

        }
        public async Task<ActiveMeasurePoint> SaveAsync(
            ActiveMeasurePoint value)
        {
            try
            {
                var result = await _context.ActiveMeasurePoints.AddAsync(value);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(2832, ex, $"Error occurred while inserting '{value}'.", value);
                return null;
            }
        }

        public async Task<ActiveMeasurePoint> UpdateAsync(
            Guid id,
            ActiveMeasurePoint value)
        {
            try
            {
                var tmp = await _context.ActiveMeasurePoints.FirstOrDefaultAsync(x => x.Id == id);
                _context.Entry(tmp).State = EntityState.Modified;
                tmp.IsActive = value.IsActive;
                tmp.LastValue = value.LastValue;
                tmp.Point = value.Point;
                tmp.Updated = DateTimeOffset.Now;
                await _context.SaveChangesAsync();
                return tmp;
            }
            catch (Exception ex)
            {
                _logger.LogError(2834, ex, $"Error occurred while updating '{id}'.", id, value);
                return null;
            }
        }

        public async Task<ActiveMeasurePoint> DeleteAsync(
            ActiveMeasurePoint value)
            => await DeleteAsync(value.Id);

        public async Task<ActiveMeasurePoint> DeleteAsync(
            Guid id)
        {
            try
            {
                var tmp = await _context.ActiveMeasurePoints.FirstOrDefaultAsync(x => x.Id == id);
                _context.ActiveMeasurePoints.Remove(tmp);
                await _context.SaveChangesAsync();
                return tmp;
            }
            catch (Exception ex)
            {
                _logger.LogError(2833, ex, $"Error occurred while deleting '{id}'.", id);
                return null;
            }
        }

        public async Task<IEnumerable<ActiveMeasurePoint>> GetAllAsync()
            => await _context.ActiveMeasurePoints.ToListAsync();
        
        public async Task<int> SaveBulkAsync(
            ActiveMeasurePoint[] values)
        {
            try
            {
                await _context.ActiveMeasurePoints.AddRangeAsync(values);
                var result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(2835,ex, $"Error occurred while inserting bulk.", values);
                return -1;
            }
        }

        public async Task<ActiveMeasurePoint> GetAsync(
            Guid id)
        {
            try
            {
                var current = await _context.ActiveMeasurePoints.FirstOrDefaultAsync(x => x.Id == id);
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