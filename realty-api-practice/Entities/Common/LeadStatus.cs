namespace realty_api_practice.Entities.Common
{
    public class LeadStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool Active { get; set; }

        public ICollection<Lead> Leads { get; set; } = new List<Lead>(); //leadStatus many leads


    }
}
