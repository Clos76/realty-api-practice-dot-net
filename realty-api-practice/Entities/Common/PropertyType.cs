namespace realty_api_practice.Entities.Common
{
    public class PropertyType
    {
        public int Id { get; set; }
        public string Name { get; set; }=null!;
        public string? Description { get; set;  } 
        public bool Active { get; set; }


        // public Property Property { get; set; }=null!;
        public ICollection<Property> Properties { get; set; } = new List<Property>(); //one propertyType has many properties
    }
}
