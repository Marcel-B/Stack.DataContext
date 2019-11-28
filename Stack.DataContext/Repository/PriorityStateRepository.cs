using com.b_velop.stack.DataContext.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace com.b_velop.stack.DataContext.Repository
{
    public class PriorityStateRepository : RepositoryBase<PriorityState>, IPriorityStateRepository
    {
        public PriorityStateRepository(
            DbContext context,
            ILogger<PriorityStateRepository> logger) : base(context, logger)
        { }
    }
}
