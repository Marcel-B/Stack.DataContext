using com.b_velop.stack.DataContext.Abstract;
using com.b_velop.stack.DataContext.Entities;
using Microsoft.Extensions.Logging;

namespace com.b_velop.stack.DataContext.Repository
{
    public class MeasureValueRepository : RepositoryBase<MeasureValue>, IMeasureValueRepository
    {
        public MeasureValueRepository(
            ILogger<MeasureValueRepository> logger,
            MeasureContext context) : base(context, logger)
        { 
        }

        //public async Task<MeasureValue> DeleteAsync(
        //    MeasureValue value)
        //    => await DeleteAsync(value.Id);

        //public async Task<MeasureValue> DeleteAsync(
        //    Guid id)
        //{
        //    try
        //    {
        //        var current = await _context.MeasureValues.FirstOrDefaultAsync(x => x.Id == id);
        //        if (current == null)
        //            return null;
        //        _context.MeasureValues.Remove(current);
        //        await _context.SaveChangesAsync();
        //        return current;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(2833, ex, $"Error occurred while deleting '{id}.'", id);
        //        return null;
        //    }
        //}

        //public async Task<IEnumerable<MeasureValue>> GetAllAsync()
        //    => await _context.MeasureValues.ToListAsync();

        //public async Task<MeasureValue> GetAsync(
        //    Guid id)
        //{
        //    try
        //    {
        //        var current = await _context.MeasureValues.FirstOrDefaultAsync(x => x.Id == id);
        //        return current;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(2831, ex, $"Error occurred while getting '{id}'.", id);
        //        return null;
        //    }
        //}

        //public async Task<MeasureValue> SaveAsync(
        //    MeasureValue value)
        //{
        //    try
        //    {
        //        var result = await _context.MeasureValues.AddAsync(value);
        //        await _context.SaveChangesAsync();
        //        return result.Entity;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(2832, ex, $"Error occurred while inserting '{value.Id}'.", value);
        //        return null;
        //    }
        //}

        //public async Task<int> SaveBulkAsync(
        //    MeasureValue[] values)
        //{
        //    try
        //    {
        //        await _context.MeasureValues.AddRangeAsync(values);
        //        var result = await _context.SaveChangesAsync();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(2835, ex, $"Error occurred while inserting bulk.", values);
        //        return -1;
        //    };
        //}

        //public async Task<MeasureValue> UpdateAsync(
        //    Guid id,
        //    MeasureValue value)
        //{
        //    try
        //    {
        //        var current = await _context.MeasureValues.FirstOrDefaultAsync(x => x.Id == id);
        //        if (current == null)
        //        {
        //            await _context.MeasureValues.AddAsync(value);
        //            await _context.SaveChangesAsync();
        //            return value;
        //        }
        //        _context.Entry(current).State = EntityState.Modified;
        //        current.Point = value.Point;
        //        current.Timestamp = value.Timestamp;
        //        current.Value = value.Value;
        //        current.Updated = DateTimeOffset.Now;
        //        var result = await _context.SaveChangesAsync();
        //        return current;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(2834, ex, $"Error occurred while updating '{id}'.", id, value);
        //        return null;
        //    }
        //}

        //public async Task<IEnumerable<MeasureValue>> FilterPointValuesByTimeAsync(
        //    Guid pointId,
        //    int seconds)
        //{
        //    try
        //    {
        //        var current = await Task.Run(() => _context
        //          .MeasureValues
        //          .Where(x => x.Point == pointId)
        //          .Where(x => x.Timestamp >= DateTimeOffset.Now.AddSeconds(-seconds))
        //          .OrderByDescending(x => x.Timestamp));

        //        return current;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(2831, ex, $"Error occurred while getting '{pointId}' until '{seconds}' seconds.", pointId, seconds);
        //        return null;
        //    }
        //}

        //public async Task<IEnumerable<MeasureValue>> FilterValuesByTimeAsync(
        //        int seconds)
        //{
        //    try
        //    {
        //        var current = await Task.Run(() => _context
        //            .MeasureValues
        //            .Where(x => x.Timestamp >= DateTimeOffset.Now.AddSeconds(-seconds))
        //            .OrderByDescending(x => x.Timestamp));

        //        return current;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(2831, ex, $"Error occurred while getting values until '{seconds}' seconds.", seconds);
        //        return null;
        //    }
        //}
    }
}
