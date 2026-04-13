using realty_api_practice.Entities.Common;
namespace realty_api_practice.Entities.Common
{
    public class LeadAssignment
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public Lead Lead { get; set; } = null!;
        public User User { get; set; } = null!;

        //lead // 


    }
}
