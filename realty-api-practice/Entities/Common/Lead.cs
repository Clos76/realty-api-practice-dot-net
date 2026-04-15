namespace realty_api_practice.Entities.Common
{
    public class Lead
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Message { get; set; }
        public int PropertyId { get; set; }
        public int LeadStatusId { get; set; }
        public int LeadSourceId { get; set; }
        public int? IntentId { get; set; }
        public int? TimeFrameId { get; set; }
       
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int? BudgetMax { get; set; }
        public int? BudgetMin { get; set; }


        //nav

        public Property Properties { get; set; } = null!;

        public LeadStatus LeadStatus { get; set; } = null!;
        public LeadSource LeadSource { get; set; } = null!;
        public Intent Intent { get; set; } = null!;
        public TimeFrame TimeFrame { get; set; } = null!;
     

       


        //many side
        public ICollection <LeadAssignment> LeadAssignments { get; set; } = new List<LeadAssignment>();
        public ICollection<PropertyView> PropertyViews { get; set; } = new List<PropertyView>();

    }
}
