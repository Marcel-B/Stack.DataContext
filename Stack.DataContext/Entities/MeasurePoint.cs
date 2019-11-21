using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.b_velop.stack.DataContext.Entities
{
    public class MeasurePoint : Entity
    {
        public string Display { get; set; }
        public double Max { get; set; }
        public double Min { get; set; }
        public string ExternId { get; set; }

        public Guid Unit { get; set; }
        public Guid Location { get; set; }

        [ForeignKey("Unit")]
        public Unit UnitObj { get; set; }

        [ForeignKey("Location")]
        public Location LocationObj { get; set; }

        public override string ToString()
            => $"MeasurePoint:{Id}:{Created}:{ExternId}:{Display}:{Max}:{Min}:{Unit}:{Location}:{Updated}";
    }
}