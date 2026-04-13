using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using realty_api_practice.Entities.Common;

namespace realty_api_practice.Entities.Constraints
{
    public class PropertyImageConstraint : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {
            builder.ToTable("PropertyImage");

            builder.HasKey(pi => pi.Id);
            builder.Property(pi => pi.Id).ValueGeneratedOnAdd();

            builder.Property(pi => pi.PropertyId)
                .IsRequired();

            builder.Property(pi => pi.ImageUrl)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(pi => pi.IsPrimary)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(pi => pi.SortOrder)
                .IsRequired();

            builder.Property(pi => pi.CreatedOn)
                .IsRequired();


            builder.HasOne(pi => pi.Property)
                .WithMany(p => p.Images)
                .HasForeignKey(pi => pi.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);


                builder.HasIndex(pi => pi.PropertyId);

        }
    }
}
