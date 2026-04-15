namespace realty_api_practice.DTOs.Property
{
    public class PropertyCreateDto
    {
        //what the cleint ends when CREATING a property (post)
        //no id , no createdon ---server sets those. 
        public string Title { get; set; }=string .Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public string Address { get; set; } = string.Empty;
       
        public int CityId { get; set; }
        public int? SquareFeet { get; set;  }
        public int? LotSize { get; set; }
        public int YearBuilt { get; set; }

        public int? ParkingSpaces { get; set; }
        public int? HOAFees { get; set; }

        public int PropertyTypeId { get; set; }
        public int LegalStatusId { get; set; }
        public int ListingSourceId { get; set;  }
    }
}
