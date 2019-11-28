using System;

namespace com.b_velop.stack.DataContext.Entities
{
    public class StackUser : Entity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
