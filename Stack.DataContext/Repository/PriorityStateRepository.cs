using com.b_velop.stack.DataContext.Entities;
using com.b_velop.stack.DataContext.Abstract;
using Microsoft.Extensions.Logging;
namespace com.b_velop.stack.DataContext.Repository
{
    public class PriorityStateRepository : RepositoryBase<PriorityState>, IPriorityStateRepository
    {
        public PriorityStateRepository(
            MeasureContext context,
            ILogger<PriorityStateRepository> logger) : base(context, logger)
        { }
    }
}
