using Microsoft.Identity.Client;

namespace realty_api_practice.Entities.Common
{
    public class UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public bool Active { get; set; }

        public User User { get; set; } = null!;
        public Role Role { get; set;  } = null!;
    }
}
