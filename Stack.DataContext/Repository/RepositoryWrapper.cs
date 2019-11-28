using com.b_velop.stack.DataContext.Abstract;
using Microsoft.Extensions.Logging;

namespace com.b_velop.stack.DataContext.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private MeasureContext _db;
        private ILogger<RepositoryWrapper> _logger;

        public IMeasurePointRepository MeasurePoint { get; set; }
        public ILocationRepository Location { get; set; }
        public IMeasureValueRepository MeasureValue { get; set; }
        public ILinkRepository Link { get; set; }
        public IPriorityStateRepository PriorityState { get; set; }
        public IUnitRepository Unit { get; set; }
        public IActiveMeasurePointRepository ActiveMeasurePoint { get; set; }
        public IBatteryStateRepository BatteryState { get; set; }
        public IAirUserRepository AirUser { get; set; }


        public RepositoryWrapper(
          MeasureContext db,
          IMeasurePointRepository measurePoint,
          ILocationRepository location,
          IMeasureValueRepository measureValue,
          ILinkRepository link,
          IPriorityStateRepository priorityState,
          IUnitRepository unit,
          IActiveMeasurePointRepository activeMeasurePoint,
          IBatteryStateRepository batteryState,
          IAirUserRepository airUser,
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
            AirUser = airUser;
            _logger = logger;
        }
    }
}
