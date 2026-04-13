namespace realty_api_practice.Entities.Common
{
    public class Intent
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        //nav
        public ICollection<Lead> Leads { get; set; } = new List<Lead>();
    }
}
