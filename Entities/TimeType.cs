using System;
using System.ComponentModel.DataAnnotations;
using com.b_velop.stack.DataContext.Repository;

namespace com.b_velop.stack.DataContext.Entities
{
    public abstract class TimeType : IEntity, ITimeEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
