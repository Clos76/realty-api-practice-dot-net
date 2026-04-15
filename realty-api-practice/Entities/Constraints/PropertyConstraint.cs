using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using realty_api_practice.Entities.Common;

namespace realty_api_practice.Entities.Constraints
{
    public class PropertyConstraint : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .HasMaxLength(1000)
                .IsRequired(false);

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.Bedrooms)
                .IsRequired();

            builder.Property(p => p.Bathrooms)
               .IsRequired();

            builder.Property(p => p.CityId).IsRequired();

            builder.Property(p => p.PropertyTypeId).IsRequired();

            builder.Property(p => p.LegalStatusId).IsRequired(); 
            builder.Property(p=> p.ListingSourceId).IsRequired();
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p=> p.Active).IsRequired();


            builder.Property(p => p.SquareFeet).IsRequired(false);
            builder.Property(p => p.LotSize).IsRequired(false);

            builder.Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p=> p.YearBuilt)
                .IsRequired ();

            builder.Property(p => p.ParkingSpaces);
            builder.Property(p=> p.HOAFees);

            builder.Property(p => p.UpdatedOn).IsRequired();



            /// / Relationships
            builder.HasOne(p => p.City)
                .WithMany(c => c.Properties)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(p => p.PropertyType)
                .WithMany(pt => pt.Properties)
                .HasForeignKey(p=> p.PropertyTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.LegalStatus)
                .WithMany(ls=> ls.Properties)
                .HasForeignKey(p=> p.LegalStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.ListingSource)
                .WithMany(ls => ls.Properties)
                .HasForeignKey(p => p.ListingSourceId)
                .OnDelete(DeleteBehavior.Restrict);


            //property images 1 To many
            builder.HasMany( p =>  p.Images)
                .WithOne(i=> i.Property)
                .HasForeignKey(i => i.PropertyId);

            //index performance
            builder.HasIndex(p => p.CityId);
            builder.HasIndex(p => p.Price);
            builder.HasIndex(p => p.PropertyTypeId);
            builder.HasIndex(p => p.Active);


        }
    }
}
