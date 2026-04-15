namespace realty_api_practice.Entities.Common
{
    public class PropertyAssignment
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public Property Property { get; set; } = null!;

        public User User { get; set; } = null!;

        //public ICollection<Property> Properties { get; set; } = new List<Property>();
        //public ICollection<User> Users { get; set; } = new List<User>();
    }
}
