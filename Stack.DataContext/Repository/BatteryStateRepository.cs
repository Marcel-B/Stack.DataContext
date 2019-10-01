using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.b_velop.stack.DataContext.Entities;
using com.b_velop.stack.DataContext.Abstract;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace com.b_velop.stack.DataContext.Repository
{
    public class BatteryStateRepository : IDataStore<BatteryState>
    {
        private readonly MeasureContext _context;
        private readonly ILogger<BatteryStateRepository> _logger;

        public BatteryStateRepository(
            MeasureContext context,
            ILogger<BatteryStateRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<BatteryState> DeleteAsync(
            BatteryState value)
            => await DeleteAsync(value.Id);

        public async Task<BatteryState> DeleteAsync(
            Guid id)
        {
            try
            {
                var tmp = await _context.BatteryStates.FirstOrDefaultAsync(x => x.Id == id);
                if(tmp != null)
                {
                    _context.BatteryStates.Remove(tmp);
                    await _context.SaveChangesAsync();
                    return tmp;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(2813, ex, $"Error occurred while deleting '{id}'.", id);
                return null;
            }
        }

        public async Task<IEnumerable<BatteryState>> GetAllAsync()
            => await _context.BatteryStates.ToListAsync();

        public async Task<BatteryState> GetAsync(
            Guid id)
        {
            try
            {
                var current = await _context.BatteryStates.FirstOrDefaultAsync(x => x.Id == id);
                return current;
            }
            catch (Exception ex)
            {
                _logger.LogError(2831, ex, $"Error occurred while getting '{id}'.", id);
                return null;
            }
        }

        public async Task<BatteryState> SaveAsync(
            BatteryState value)
        {
            try
            {
                var result = await _context.AddAsync(value);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(2812, ex, $"Error occurred while inserting '{value.Id}'.", value);
                return null;
            }
        }

        public async Task<int> SaveBulkAsync(
            BatteryState[] values)
        {
            try
            {
                await _context.BatteryStates.AddRangeAsync(values);
                var result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(2815, ex, $"Error occurred while inserting bulk.", values);
                return -1;
            }
        }

        public async Task<IEnumerable<BatteryState>> UpdateStatesAsync(
            IEnumerable<Guid> ids,
            IEnumerable<DateTimeOffset> timestamps,
            IEnumerable<bool> states)
        {
            var i = 0;
            var ret = new List<BatteryState>();
            foreach (var id in ids)
            {
                i = ret.Count;
                var current = await _context.BatteryStates.FirstOrDefaultAsync(x => x.Id == id);
                _context.Entry(current).State = EntityState.Modified;
                current.State = states.ElementAt(i);
                current.Timestamp = timestamps.ElementAt(i);
                current.Updated = DateTimeOffset.Now;
                ret.Add(current);
            }
            await _context.SaveChangesAsync();
            return ret;
        }

        public async Task<BatteryState> UpdateAsync(
            Guid id,
            BatteryState value)
        {
            try
            {
                var current = await _context.BatteryStates.FirstOrDefaultAsync(x => x.Id == id);
                _context.Entry(current).State = EntityState.Modified;
                current.Point = value.Point;
                current.State = value.State;
                current.Timestamp = value.Timestamp;
                current.Updated = DateTimeOffset.Now;
                await _context.SaveChangesAsync();
                return current;
            }
            catch (Exception ex)
            {
                _logger.LogError(2814, ex, $"Error occurred while updating '{id}'.", id);
                return null;
            }
        }
    }
}
