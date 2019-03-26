using com.b_velop.stack.DataContext.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace com.b_velop.stack.DataContext.Entities
{
    public class MeasurePoint : IEntity
    {
        [Key]
        public Guid Id { get; set; }
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

    }
}