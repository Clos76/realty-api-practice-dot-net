using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using realty_api_practice.Entities.Common;

namespace realty_api_practice.Entities.Constraints
{
    public class LegalStatusConstraint : IEntityTypeConfiguration<LegalStatus>
    {
        public void Configure(EntityTypeBuilder<LegalStatus> builder)
        {
            builder.ToTable("LegalStatus");

            builder.HasKey(ls=> ls.Id);
            builder.Property(ls => ls.Id)
                .ValueGeneratedOnAdd();

            builder.Property(ls => ls.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ls => ls.Description)
                .IsRequired(false)
                .HasMaxLength(1000);


                
        }
    }
}
