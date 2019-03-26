using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.b_velop.stack.DataContext.Abstract;
using com.b_velop.stack.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace com.b_velop.stack.DataContext.Repository
{
    public class MeasurePointsRepository : IDataStore<MeasurePoint>
    {
        private readonly ILogger<MeasurePointsRepository> _logger;
        private readonly MeasureContext _context;

        public MeasurePointsRepository(
            MeasureContext context,
            ILogger<MeasurePointsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<MeasurePoint> SaveAsync(
            MeasurePoint value)
        {
            try
            {
                var result = await _context.MeasurePoints.AddAsync(value);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(2222, ex, $"Error occurred while insert new MeasurePoint '{value}'", value);
                return null;
            }
        }

        public async Task<MeasurePoint> UpdateAsync(
            Guid id,
            MeasurePoint value)
        {
            try
            {
                var tmp = await _context.MeasurePoints.FirstOrDefaultAsync(x => x.Id == id);
                _context.Entry(tmp).State = EntityState.Modified;
                tmp.Display = value.Display;
                tmp.Location = value.Location;
                tmp.Max = value.Max;
                tmp.Min = value.Min;
                tmp.Unit = value.Unit;
                tmp.ExternId = value.ExternId;
                await _context.SaveChangesAsync();
                return tmp;
            }
            catch (Exception ex)
            {
                _logger.LogError(2222, ex, $"Error occurred while updating MeasurePoint '{id}'", id, value);
                return null;
            }
        }

        public async Task<MeasurePoint> DeleteAsync(
            MeasurePoint value)
            => await DeleteAsync(value.Id);

        public async Task<MeasurePoint> DeleteAsync(
            Guid id)
        {
            try
            {
                var tmp = await _context.MeasurePoints.FirstOrDefaultAsync(x => x.Id == id);
                _context.MeasurePoints.Remove(tmp);
                await _context.SaveChangesAsync();
                return tmp;
            }
            catch (Exception ex)
            {
                _logger.LogError(2222, ex, $"Error occurred while deleting MeasurePoint '{id}'.", id);
                return null;
            }
        }

        public async Task<IEnumerable<MeasurePoint>> GetAllAsync()
            => await _context.MeasurePoints.ToListAsync();

        public async Task<int> SaveBulkAsync(
            MeasurePoint[] values)
        {
            try
            {
                await _context.MeasurePoints.AddRangeAsync(values);
                var result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger. LogError(2222, ex, $"Error occurred while save MeasurePoints.", values);
                return -1;
            }
        }
    }
}