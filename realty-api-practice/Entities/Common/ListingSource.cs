namespace realty_api_practice.Entities.Common
{
    public class ListingSource
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Active { get; set; }

        public ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}
