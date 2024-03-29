﻿using com.b_velop.stack.DataContext.Abstract;
using com.b_velop.stack.DataContext.Entities;
using Microsoft.Extensions.Logging;

namespace com.b_velop.stack.DataContext.Repository
{

    public class AirUserRepository : RepositoryBase<AirUser>, IAirUserRepository
    {
        public AirUserRepository(
            MeasureContext db,
            ILogger<RepositoryBase<AirUser>> logger) : base(db, logger)
        {
        }
    }
}