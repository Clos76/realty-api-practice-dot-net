using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using realty_api_practice.Entities.Common;

namespace realty_api_practice.Entities.Constraints
{
    public class TimeFrameConstraint : IEntityTypeConfiguration<TimeFrame>
    {
        public void Configure(EntityTypeBuilder<TimeFrame> builder)
        {
            builder.ToTable("TimeFrames");

            builder.HasKey(tf => tf.Id);
            builder.Property(tf => tf.Id)
                .ValueGeneratedOnAdd();

            builder.Property(tf => tf.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
