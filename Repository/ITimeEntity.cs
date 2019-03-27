using System;

namespace com.b_velop.stack.DataContext.Repository
{
    public interface ITimeEntity
    {
        DateTimeOffset Timestamp { get; set; }
    }
}
