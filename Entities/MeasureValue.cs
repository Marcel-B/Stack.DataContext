using com.b_velop.stack.DataContext.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace com.b_velop.stack.DataContext.Entities
{
    public class MeasureValue : TimeType
    {
        public double Value { get; set; }

        public Guid Point { get; set; }

        [ForeignKey("Point")]
        public MeasurePoint PointObj { get; set; }
    }
}
