using com.b_velop.stack.DataContext.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace com.b_velop.stack.DataContext.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DbContext _db;
        private ILogger<RepositoryWrapper> _logger;

        public IMeasurePointRepository MeasurePoint { get; set; }
        public ILocationRepository Location { get; set; }
        public IMeasureValueRepository MeasureValue { get; set; }
        public ILinkRepository Link { get; set; }
        public IPriorityStateRepository PriorityState { get; set; }
        public IUnitRepository Unit { get; set; }
        public IActiveMeasurePointRepository ActiveMeasurePoint { get; set; }
        public IBatteryStateRepository BatteryState { get; set; }


        public RepositoryWrapper(
          DbContext db,
          IMeasurePointRepository measurePoint,
          ILocationRepository location,
          IMeasureValueRepository measureValue,
          ILinkRepository link,
          IPriorityStateRepository priorityState,
          IUnitRepository unit,
          IActiveMeasurePointRepository activeMeasurePoint,
          IBatteryStateRepository batteryState,
          ILogger<RepositoryWrapper> logger)
        {
            _db = db;
            MeasurePoint = measurePoint;
            Location = location;
            MeasureValue = measureValue;
            Link = link;
            PriorityState = priorityState;
            Unit = unit;
            ActiveMeasurePoint = activeMeasurePoint;
            BatteryState = batteryState;
            _logger = logger;
        }
    }
}
