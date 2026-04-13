using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using realty_api_practice.Entities.Common;

namespace realty_api_practice.Entities.Constraints
{
    public class ListingSourceConstraint : IEntityTypeConfiguration<ListingSource>
    {
        public void Configure(EntityTypeBuilder<ListingSource> builder)
        {
            builder.ToTable("ListingSource");
            builder.HasKey(ls => ls.Id);
            builder.Property(ls => ls.Id).ValueGeneratedOnAdd();

            builder.Property(ls => ls.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ls => ls.Active)
                .IsRequired();

        }
    }
}
