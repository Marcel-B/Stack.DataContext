using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.b_velop.stack.DataContext.Entities
{
    public class ActiveMeasurePoint : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public double LastValue { get; set; }
        public DateTimeOffset Updated { get; set; }
        public Guid Point { get; set; }

        [ForeignKey("Point")]
        public MeasurePoint PointObj { get; set; }
    }
}
