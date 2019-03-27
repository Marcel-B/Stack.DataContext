using System;
using System.ComponentModel.DataAnnotations;

namespace com.b_velop.stack.DataContext.Entities
{
    public abstract class TimeType : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
