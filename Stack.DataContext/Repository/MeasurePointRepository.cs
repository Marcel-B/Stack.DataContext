using com.b_velop.stack.DataContext.Abstract;
using com.b_velop.stack.DataContext.Entities;
using Microsoft.Extensions.Logging;

namespace com.b_velop.stack.DataContext.Repository
{
    public class MeasurePointRepository : RepositoryBase<MeasurePoint>, IMeasurePointRepository
    {
        public MeasurePointRepository(
            MeasureContext context,
            ILogger<MeasurePointRepository> logger) : base(context, logger)
        { }

        //public async Task<MeasurePoint> SaveAsync(
        //    MeasurePoint value)
        //{
        //    try
        //    {
        //        var result = await _context.MeasurePoints.AddAsync(value);
        //        await _context.SaveChangesAsync();
        //        return result.Entity;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(2832, ex, $"Error occurred while inserting '{value}'", value);
        //        return null;
        //    }
        //}

        //public async Task<MeasurePoint> UpdateAsync(
        //    Guid id,
        //    MeasurePoint value)
        //{
        //    try
        //    {
        //        var current = await _context.MeasurePoints.FirstOrDefaultAsync(x => x.Id == id);
        //        _context.Entry(current).State = EntityState.Modified;
        //        current.Display = value.Display;
        //        current.Location = value.Location;
        //        current.Max = value.Max;
        //        current.Min = value.Min;
        //        current.Unit = value.Unit;
        //        current.ExternId = value.ExternId;
        //        current.Updated = DateTimeOffset.Now;
        //        await _context.SaveChangesAsync();
        //        return current;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(2834, ex, $"Error occurred while updating '{id}'", id, value);
        //        return null;
        //    }
        //}

        //public async Task<MeasurePoint> DeleteAsync(
        //    MeasurePoint value)
        //    => await DeleteAsync(value.Id);

        //public async Task<MeasurePoint> DeleteAsync(
        //    Guid id)
        //{
        //    try
        //    {
        //        var tmp = await _context.MeasurePoints.FirstOrDefaultAsync(x => x.Id == id);
        //        _context.MeasurePoints.Remove(tmp);
        //        await _context.SaveChangesAsync();
        //        return tmp;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(2833, ex, $"Error occurred while deleting '{id}'.", id);
        //        return null;
        //    }
        //}

        //public async Task<IEnumerable<MeasurePoint>> GetAllAsync()
        //    => await _context.MeasurePoints.ToListAsync();

        //public async Task<int> SaveBulkAsync(
        //    MeasurePoint[] values)
        //{
        //    try
        //    {
        //        await _context.MeasurePoints.AddRangeAsync(values);
        //        var result = await _context.SaveChangesAsync();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(2835, ex, $"Error occurred while inserting bulk.", values);
        //        return -1;
        //    }
        //}

        //public async Task<MeasurePoint> GetAsync(Guid id)
        //{
        //    try
        //    {
        //        var current = await _context.MeasurePoints.FirstOrDefaultAsync(x => x.Id == id);
        //        return current;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(2831, ex, $"Error occurred while getting '{id}'.", id);
        //        return null;
        //    }
        //}
    }
}