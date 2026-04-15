namespace realty_api_practice.Entities.Common
{
    public class Property
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; } 
        public int Price { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set;  }
        public int CityId { get; set; }
        public int PropertyTypeId { get; set;  }
        public int LegalStatusId { get; set; }
        public int ListingSourceId { get; set; }
        public DateTime CreatedOn { get; set;  }
        public bool Active { get; set;  }
        public int? SquareFeet { get; set;  }
        public int? LotSize { get; set; }
        public string Address { get; set; } = null!;
        public int YearBuilt { get; set; }
        public int? ParkingSpaces { get; set; }
        public int? HOAFees { get; set; }
        public DateTime UpdatedOn { get; set;  }


        // Navigation properties
        public City City { get; set; } = null!;
        public PropertyType PropertyType { get; set; } = null!;//each property belongs to one propertyType
        public LegalStatus LegalStatus { get; set; } = null!;

        public ListingSource ListingSource { get; set; } = null!;

       



       ///many leads for one property
       public ICollection<Lead> Leads { get; set; } = new List<Lead>();

        //images
        public ICollection<PropertyImage> Images { get; set; } = new List<PropertyImage>();

        public ICollection<PropertyView> PropertyViews { get; set; } = new List<PropertyView>();

        public ICollection<PropertyAssignment> PropertyAssignments { get; set; } = new List<PropertyAssignment>();


    }
}
