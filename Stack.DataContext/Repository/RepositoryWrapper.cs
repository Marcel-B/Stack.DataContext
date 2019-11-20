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

        public RepositoryWrapper(
          MeasureContext db,
          IMeasurePointRepository measurePoint,
          ILocationRepository location,
          ILogger<RepositoryWrapper> logger)
        {
            _db = db;
            MeasurePoint = measurePoint;
            Location = location;
            _logger = logger;
        }
    }
}
