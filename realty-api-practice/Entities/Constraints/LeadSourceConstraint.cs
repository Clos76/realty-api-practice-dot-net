using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using realty_api_practice.Entities.Common;

namespace realty_api_practice.Entities.Constraints
{
    public class LeadSourceConstraint : IEntityTypeConfiguration<LeadSource>
    {
        public void Configure(EntityTypeBuilder<LeadSource> builder)
        {
            builder.ToTable("LeadSources");

            builder.HasKey(ls => ls.Id);
            builder.Property(ls => ls.Id)
                .ValueGeneratedOnAdd();

            builder.Property(ls => ls.Name)
                .IsRequired()
                .HasMaxLength(50);


        }
    }
}
