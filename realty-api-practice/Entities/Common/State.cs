namespace realty_api_practice.Entities.Common
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;


        //navigation
        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
