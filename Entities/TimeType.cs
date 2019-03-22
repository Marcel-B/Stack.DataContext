using com.b_velop.stack.DataContext.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace com.b_velop.stack.DataContext.Entities
{
    public abstract class TimeType : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
