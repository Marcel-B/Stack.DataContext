using System;

namespace com.b_velop.stack.DataContext.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTimeOffset Created { get; set; }
        DateTimeOffset? Updated { get; set; }
    }
}
