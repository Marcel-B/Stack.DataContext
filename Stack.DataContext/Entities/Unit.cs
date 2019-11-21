namespace com.b_velop.stack.DataContext.Entities
{
    public class Unit : Entity
    {
        public string Display { get; set; }
        public string Name { get; set; }
        public override string ToString()
           => $"Unit:{Id}:{Created}:{Display}:{Name}:{Updated}";
    }
}
