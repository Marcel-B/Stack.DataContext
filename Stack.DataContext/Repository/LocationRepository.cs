using System;
using System.Threading.Tasks;
using com.b_velop.stack.DataContext.Entities;
using com.b_velop.stack.DataContext.Abstract;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace com.b_velop.stack.DataContext.Repository
{
    public class LocationRepository : IDataStore<Location>
    {
        private readonly MeasureContext _context;
        private readonly ILogger<LocationRepository> _logger;

        public LocationRepository(
            MeasureContext context,
            ILogger<LocationRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Location> DeleteAsync(
            Location value)
            => await DeleteAsync(value.Id);

        public async Task<Location> DeleteAsync(
            Guid id)
        {
            try
            {
                var current = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id);
                _context.Locations.Remove(current);
                await _context.SaveChangesAsync();
                return current;
            }
            catch (Exception ex)
            {
                _logger.LogError(2833, ex, $"Error occurred while deleting '{id}'", id);
                return null;
            }
        }

        public async Task<System.Collections.Generic.IEnumerable<Location>> GetAllAsync()
            => await _context.Locations.ToListAsync();

        public async Task<Location> GetAsync(
            Guid id)
        {
            try
            {
                var current = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id);
                return current;
            }
            catch (Exception ex)
            {
                _logger.LogError(2831, ex, $"Error occurred while getting '{id}'", id);
                return null;
            }
        }

        public async Task<Location> SaveAsync(
            Location value)
        {
            try
            {
                var result = await _context.AddAsync(value);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(2832, ex, $"Error occurred while inserting '{value.Id}'", value);
                return null;
            }
        }

        public async Task<int> SaveBulkAsync(
            Location[] values)
        {
            try
            {
                await _context.Locations.AddRangeAsync(values);
                var result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(2835, ex, $"Error occurred while inserting bulk", values);
                return -1;
            }
        }

        public async Task<Location> UpdateAsync(
            Guid id, 
            Location value)
        {
            try
            {
                var current = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id);
                _context.Entry(current).State = EntityState.Modified;
                current.Description = value.Description;
                current.Display = value.Display;
                current.Floor = value.Floor;
                current.Latitude = value.Latitude;
                current.Longitude = value.Longitude;
                current.Updated = DateTimeOffset.Now;
                await _context.SaveChangesAsync();
                return current;
            }
            catch (Exception ex)
            {
                _logger.LogError(2834, ex, $"Error occurred while updating '{id}'", id, value);
                return null;
            }
        }
    }
}
