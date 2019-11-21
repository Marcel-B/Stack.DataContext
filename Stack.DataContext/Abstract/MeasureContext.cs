using com.b_velop.stack.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace com.b_velop.stack.DataContext.Abstract
{
    public class MeasureContext : DbContext
    {
        private readonly ILogger<MeasureContext> _logger;

        public DbSet<MeasurePoint> MeasurePoints { get; set; }
        public DbSet<MeasureValue> MeasureValues { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<BatteryState> BatteryStates { get; set; }
        public DbSet<PriorityState> PriorityStates { get; set; }
        public DbSet<ActiveMeasurePoint> ActiveMeasurePoints { get; set; }
        public DbSet<Link> Links { get; set; }

        public MeasureContext(
            ILogger<MeasureContext> logger,
            DbContextOptions<MeasureContext> context) : base(context)
        {
            _logger = logger;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException(nameof(modelBuilder));
            modelBuilder.Seed();
        }
    }
}