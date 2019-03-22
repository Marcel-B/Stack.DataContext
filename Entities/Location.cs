using com.b_velop.stack.DataContext.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace com.b_velop.stack.DataContext.Entities
{
    public class Location : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Display { get; set; }
        public string Description { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public int? Floor { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
