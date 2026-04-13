

using Microsoft.EntityFrameworkCore;
using realty_api_practice.Entities.Common;

namespace realty_api_practice.Entities.Constraints

{
    public class PropertyTypeConstraint : IEntityTypeConfiguration<PropertyType>
    {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PropertyType> builder)
        {
            builder.ToTable("PropertyType");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).HasMaxLength(1000);
            builder.Property(p => p.Active).IsRequired();

           
        }
    }

}