using com.b_velop.stack.DataContext.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.b_velop.stack.DataContext.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private MeasureContext _db;
        private ILogger<RepositoryWrapper> _logger;

        public IMeasurePointRepository MeasurePoint { get; set; }

        public RepositoryWrapper(
          MeasureContext db,
          IMeasurePointRepository measurePoint,
            ILogger<RepositoryWrapper> logger)
        {
            _db = db;
            MeasurePoint = measurePoint;
            _logger = logger;
        }
    }
}
