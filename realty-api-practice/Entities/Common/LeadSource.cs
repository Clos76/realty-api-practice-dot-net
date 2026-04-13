namespace realty_api_practice.Entities.Common
{
    public class LeadSource
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Lead> Leads { get; set; } = new List<Lead>();
    }
}
