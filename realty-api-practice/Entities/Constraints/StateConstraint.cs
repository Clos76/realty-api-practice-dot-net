using Microsoft.EntityFrameworkCore;
using realty_api_practice.Entities.Common;

namespace realty_api_practice.Entities.Constraints
{
    public class StateConstraint : IEntityTypeConfiguration<State>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<State> builder)
        {
            builder.ToTable("State");

            builder.HasKey(s => s.Id);
            builder.Property(s=> s.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
