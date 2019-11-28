using com.b_velop.stack.DataContext.Entities;
using Microsoft.Extensions.Logging;
using com.b_velop.stack.DataContext.Abstract;

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
