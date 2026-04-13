namespace realty_api_practice.Entities.Common
{
    public class LegalStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        // Navigation properties-- no have nothign but property collection has , we use icollection because one legal status can be associated with multiple properties
        public ICollection<Property> Properties { get; set; } = new List<Property>();


    }
}
