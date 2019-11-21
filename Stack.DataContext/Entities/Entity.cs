using System;
using System.ComponentModel.DataAnnotations;

namespace com.b_velop.stack.DataContext.Entities
{
    public abstract class Entity : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
    }
}
