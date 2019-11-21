using com.b_velop.stack.DataContext.Entities;
using com.b_velop.stack.DataContext.Abstract;
using Microsoft.Extensions.Logging;

namespace com.b_velop.stack.DataContext.Repository
{
    public class BatteryStateRepository : RepositoryBase<BatteryState>, IBatteryStateRepository
    {
        public BatteryStateRepository(
            MeasureContext context,
            ILogger<BatteryStateRepository> logger) : base(context, logger) { }

        //public async Task<IEnumerable<BatteryState>> UpdateStatesAsync(
        //    IEnumerable<Guid> ids,
        //    IEnumerable<DateTimeOffset> timestamps,
        //    IEnumerable<bool> states)
        //{
        //    var i = 0;
        //    var ret = new List<BatteryState>();
        //    foreach (var id in ids)
        //    {
        //        i = ret.Count;
        //        var current = await _context.BatteryStates.FirstOrDefaultAsync(x => x.Id == id);
        //        _context.Entry(current).State = EntityState.Modified;
        //        current.State = states.ElementAt(i);
        //        current.Timestamp = timestamps.ElementAt(i);
        //        current.Updated = DateTimeOffset.Now;
        //        ret.Add(current);
        //    }
        //    await _context.SaveChangesAsync();
        //    return ret;
        //}

        //public async Task<BatteryState> UpdateAsync(
        //    Guid id,
        //    BatteryState value)
        //{
        //    try
        //    {
        //        var current = await _context.BatteryStates.FirstOrDefaultAsync(x => x.Id == id);
        //        _context.Entry(current).State = EntityState.Modified;
        //        current.Point = value.Point;
        //        current.State = value.State;
        //        current.Timestamp = value.Timestamp;
        //        current.Updated = DateTimeOffset.Now;
        //        await _context.SaveChangesAsync();
        //        return current;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(2814, ex, $"Error occurred while updating '{id}'.", id);
        //        return null;
        //    }
        //}
    }
}
