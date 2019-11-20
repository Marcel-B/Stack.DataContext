using com.b_velop.stack.DataContext.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace com.b_velop.stack.DataContext
{
    public static class StackDataContextApplicationBuilderExtensions
    {
        public static IServiceCollection UseStackDataContext(
          this IServiceCollection services)
        {
            services.AddScoped<IMeasurePointRepository, MeasurePointRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IMeasureValueRepository, MeasureValueRepository>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<ILinkRepository, LinkRepository>();
            services.AddScoped<IPriorityStateRepository, PriorityStateRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IActiveMeasurePointRepository, ActiveMeasurePointRepository>();
            services.AddScoped<IBatteryStateRepository, BatteryStateRepository>();
            return services;
        }
        public static IApplicationBuilder UseStackDataContext(
            this IApplicationBuilder app)
        {
            return app;
        }
    }
}
