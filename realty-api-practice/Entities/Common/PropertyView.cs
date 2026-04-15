namespace realty_api_practice.Entities.Common
{
    public class PropertyView
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public int LeadId { get; set; }
        public DateTime ViewedOn { get; set; }
        public string SessionId { get; set; } = null!;
        public string IpAddress { get; set; } = null!;

        public Lead Lead { get; set; } = null!;
        public Property Property { get; set; } = null!;

      
       

    }
}
