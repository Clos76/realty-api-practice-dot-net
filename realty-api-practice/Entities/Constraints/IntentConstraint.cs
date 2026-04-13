using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using realty_api_practice.Entities.Common;

namespace realty_api_practice.Entities.Constraints
{
    public class IntentConstraint : IEntityTypeConfiguration<Intent>
    {
        public void Configure(EntityTypeBuilder<Intent> builder)
        {
            builder.ToTable("Intents");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
