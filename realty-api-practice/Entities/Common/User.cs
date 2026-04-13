namespace realty_api_practice.Entities.Common
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Active { get; set; }

        public ICollection<LeadAssignment> LeadAssignments { get; set; } = new List<LeadAssignment>();
    }
}
