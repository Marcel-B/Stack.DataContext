using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.b_velop.stack.DataContext.Entities
{
    public class PriorityState : TimeType
    {
        public bool State { get; set; }

        public Guid Point { get; set; }

        [ForeignKey("Point")]
        public MeasurePoint PointObj { get; set; }
    }
}
