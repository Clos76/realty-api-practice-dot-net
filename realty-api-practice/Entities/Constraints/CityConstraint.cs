using Microsoft.EntityFrameworkCore;
using realty_api_practice.Entities.Common;

namespace realty_api_practice.Entities.Constraints
{
    public class CityConstraint : IEntityTypeConfiguration<City>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");

            builder.HasKey(c => c.Id);
            builder.Property(c=> c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.StateId)
                .IsRequired();

            // Define the relationship with State
            builder.HasOne(c => c.State)
                .WithMany(s => s.Cities)
                .HasForeignKey(c => c.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(c => c.StateId);
        }
    }
}
