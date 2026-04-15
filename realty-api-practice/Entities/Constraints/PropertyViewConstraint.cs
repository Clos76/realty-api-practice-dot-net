using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using realty_api_practice.Entities.Common;

namespace realty_api_practice.Entities.Constraints
{
    public class PropertyViewConstraint : IEntityTypeConfiguration<PropertyView>
    {
        public void Configure(EntityTypeBuilder<PropertyView> builder)
        {
            builder.ToTable("PropertyViews");

            builder.HasKey(pv=>pv.Id);
            builder.Property(pv=> pv.Id)
                .ValueGeneratedOnAdd();

            builder.Property(pv=> pv.PropertyId)
                .IsRequired();

            builder.Property(pv=>pv.LeadId)
                .IsRequired();

            builder.Property(pv=>pv.ViewedOn)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(pv=> pv.SessionId)
                .IsRequired();

            builder.Property(pv=> pv.IpAddress)
                .HasMaxLength(100)
                .IsRequired();
             
            builder.HasOne(pv => pv.Property)
                .WithMany(p => p.PropertyViews)
                .HasForeignKey(pv=> pv.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pv=> pv.Lead)
                .WithMany(l=> l.PropertyViews)
                .HasForeignKey(pv=> pv.LeadId)
                .OnDelete(DeleteBehavior.Restrict);


            // Indexes
            builder.HasIndex(pv => pv.PropertyId);
            builder.HasIndex(pv=> pv.ViewedOn);
            builder.HasIndex(pv => pv.LeadId);

        }
    }
}
