namespace realty_api_practice.Entities.Common
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int StateId { get; set; }

        //nave
        public State State { get; set; } = null!; //can olny be in one state one spec city per state. 
        public ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}
