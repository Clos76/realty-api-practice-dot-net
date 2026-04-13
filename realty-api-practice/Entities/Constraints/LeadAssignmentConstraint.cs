using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using realty_api_practice.Entities.Common;

namespace realty_api_practice.Entities.Constraints
{
    public class LeadAssignmentConstraint : IEntityTypeConfiguration<LeadAssignment>
    {
        public void Configure(EntityTypeBuilder<LeadAssignment> builder)
        {
            builder.ToTable("LeadAssignments");

            builder.HasKey(la => la.Id);
            builder.Property(la => la.Id)
                .ValueGeneratedOnAdd() ;

            builder.Property(la => la.LeadId).
                IsRequired();

            builder.Property(la => la.UserId)
                .IsRequired();

            builder.Property(la => la.Active)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(la => la.CreatedOn)
                .IsRequired()
                .HasDefaultValue("GETUTCDATE()");

            builder.Property(la=> la.UpdatedOn)
                .IsRequired();


            //many 

            builder.HasOne(la => la.Lead)
                .WithMany(l => l.LeadAssignments)
                .HasForeignKey(la => la.LeadId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(la => la.User)
                .WithMany(u => u.LeadAssignments)
                .HasForeignKey(la => la.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            //indexes, 
            builder.HasIndex(la => la.LeadId);
            builder.HasIndex(la => la.UserId);


            //prevent duplicate assignments of the same lead to the same user
            builder.HasIndex(la => new { la.LeadId, la.UserId });
                
        }
    }
}
