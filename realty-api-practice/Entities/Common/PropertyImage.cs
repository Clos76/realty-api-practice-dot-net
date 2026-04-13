namespace realty_api_practice.Entities.Common
{
    public class PropertyImage
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public bool IsPrimary { get; set; }
        public int SortOrder { get; set; }
        public DateTime CreatedOn { get; set; }

        //nav 
        public Property Property { get; set; } = null!; //one property per many images

        
    }
}
