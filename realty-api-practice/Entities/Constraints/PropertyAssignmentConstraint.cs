using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using realty_api_practice.Entities.Common;

namespace realty_api_practice.Entities.Constraints
{
    public class PropertyAssignmentConstraint : IEntityTypeConfiguration<PropertyAssignment>
    {
        public void Configure(EntityTypeBuilder<PropertyAssignment> builder)
        {
            builder.ToTable("PropertyAssignments");

            builder.HasKey(pa => pa.Id);
            builder.Property(pa => pa.Id)
                .ValueGeneratedOnAdd();

            builder.Property(pa => pa.PropertyId)
                .IsRequired();

            builder.Property(pa=> pa.UserId)
                .IsRequired();

            builder.Property(pa=> pa.Active)
                .IsRequired();

            builder.Property(pa => pa.CreatedOn)
                 .IsRequired()
                 .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(pa => pa.UpdatedOn)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(pa => pa.Property)
                .WithMany(p=> p.PropertyAssignments)
                .HasForeignKey(pa => pa.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pa => pa.User)
                .WithMany(u => u.PropertyAssignments)
                .HasForeignKey(pa => pa.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(pa => new {pa.PropertyId, pa.UserId })
                .IsUnique();

        }
    }
}
