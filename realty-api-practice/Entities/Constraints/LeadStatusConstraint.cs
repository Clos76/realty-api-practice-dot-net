using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using realty_api_practice.Entities.Common;
using System.Threading.RateLimiting;

namespace realty_api_practice.Entities.Constraints
{
    public class LeadStatusConstraint : IEntityTypeConfiguration<LeadStatus>
    {
        public void Configure(EntityTypeBuilder<LeadStatus> builder)
        {
            builder.ToTable("LeadStatuses");

            builder.HasKey(ls => ls.Id);
            builder.Property(ls => ls.Id)
                .ValueGeneratedOnAdd();

            builder.Property(ls => ls.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ls => ls.Description)
                .IsRequired(false)
                .HasMaxLength(1000);

            builder.Property(ls => ls.Active)
                .IsRequired()
                .HasDefaultValue(true);

        }
    }
}
