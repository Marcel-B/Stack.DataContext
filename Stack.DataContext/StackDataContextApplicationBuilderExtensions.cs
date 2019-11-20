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
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            return services;
        }
        public static IApplicationBuilder UseStackDataContext(
            this IApplicationBuilder app)
        {
            return app;
        }
    }
}
