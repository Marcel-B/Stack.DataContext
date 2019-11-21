using System;
using System.ComponentModel.DataAnnotations;

namespace com.b_velop.stack.DataContext.Entities
{
    public class Location : Entity
    {
        public string Display { get; set; }
        public string Description { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public int? Floor { get; set; }

        public override string ToString()
            => $"Location:{Id}:{Created}:{Display}:{Description}:{Longitude}:{Latitude}:{Floor}:{Updated}";
    }
}
