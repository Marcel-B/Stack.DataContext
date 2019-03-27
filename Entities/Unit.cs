using System;
using System.ComponentModel.DataAnnotations;

namespace com.b_velop.stack.DataContext.Entities
{
    public class Unit : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? Created { get; set; }
        public DateTimeOffset? Updated { get; set; }

        public override string ToString()
           => $"Unit:{Id}:{Created}:{Display}:{Name}:{Updated}";
    }
}
