using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.b_velop.stack.DataContext.Entities
{
    public class MeasureValue : TimeType
    {
        public double Value { get; set; }

        public Guid Point { get; set; }

        public DateTimeOffset? Updated { get; set; }

        [ForeignKey("Point")]
        public MeasurePoint PointObj { get; set; }

        public override string ToString()
            => $"MeasureValue:{Id}:{Timestamp}:{Value}:{Point}:{Updated}";
    }
}
