namespace realty_api_practice.Entities.Common
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Active { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
