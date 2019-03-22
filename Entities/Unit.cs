using com.b_velop.stack.DataContext.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace com.b_velop.stack.DataContext.Entities
{
    public class Unit : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
    }
}
