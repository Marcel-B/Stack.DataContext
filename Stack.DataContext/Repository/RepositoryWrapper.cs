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


        public RepositoryWrapper(
          MeasureContext db,
          IMeasurePointRepository measurePoint,
          ILocationRepository location,
          IMeasureValueRepository measureValue,
          ILogger<RepositoryWrapper> logger)
        {
            _db = db;
            MeasurePoint = measurePoint;
            Location = location;
            MeasureValue = measureValue;
            _logger = logger;
        }
    }
}
