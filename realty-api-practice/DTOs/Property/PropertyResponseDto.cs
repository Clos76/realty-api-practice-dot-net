using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace realty_api_practice.DTOs.Property
{
    public class PropertyResponseDto
    {
      public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int Price { get; set; }
        public int Bedrooms { get; set; }  
        public int Bathrooms { get; set; }

        public string Address { get;set;  }= string.Empty;

        public int YearBuilt { get; set; }

        public int? SquareFeet { get; set;  }
        public int? LotSize { get; set;  }
        public int? ParkingSpaces { get; set;  }
        public int? HOAFees { get; set;  }

        public bool Active { get; set;  }

        public DateTime CreatedOn { get; set;  }

        //flattened realtionshps 

        public int CityId { get; set;  }
        public string CityName { get; set;  } = string.Empty ;
        public int PropertyTypeId { get; set; }
        public string LegalStatusName { get; set; } = string.Empty ;
        public int ListingSourceId { get; set; }
        public string ListingSourceName { get; set;  }= string.Empty ;

        //optional images 
        public List<string> ImageUrls { get; set; } = new();


    }
}
