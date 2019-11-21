using System;
using com.b_velop.stack.DataContext.Repository;

namespace com.b_velop.stack.DataContext.Entities
{

    public abstract class TimeType : Entity, ITimeEntity
    {
        public DateTimeOffset Timestamp { get; set; }
    }
}
