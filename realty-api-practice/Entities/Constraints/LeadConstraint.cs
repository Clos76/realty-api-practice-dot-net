using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using realty_api_practice.Entities.Common;
using System.Threading.RateLimiting;

namespace realty_api_practice.Entities.Constraints
{
    public class LeadConstraint : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.ToTable("Leads");

            builder.HasKey( l=> l.Id);
            builder.Property(l=> l.Id)
                .ValueGeneratedOnAdd() ;

            builder.Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(l => l.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(l => l.Phone)
                .IsRequired(false)
                .HasMaxLength(20);

            builder.Property(l => l.Message)
                .IsRequired(false)
                .HasMaxLength(1000);

            builder.Property(l => l.PropertyId)
                .IsRequired();

            builder.Property(l=> l.LeadStatusId) .IsRequired();
            builder.Property(l=> l.LeadSourceId).IsRequired();
            builder.Property(l=> l.IntentId) .IsRequired(false);
            builder.Property(l => l.TimeFrameId).IsRequired(false);
            

            builder.Property(l=> l.CreatedOn)
                .IsRequired();
            
            builder.Property(l=> l.UpdatedOn) 
                .IsRequired();

            builder.Property(l=> l.BudgetMax) .IsRequired(false);
            builder.Property(l=> l.BudgetMin) .IsRequired(false);


            //relationship
            builder.HasOne(l=> l.Properties)
                .WithMany(p=> p.Leads)
                .HasForeignKey(l=>l.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l=> l.LeadStatus)
                .WithMany(ls => ls.Leads)
                .HasForeignKey(l => l.LeadStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l=> l.LeadSource)
                .WithMany(ls=> ls.Leads)
                .HasForeignKey(l=> l.LeadSourceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.Intent)
                .WithMany(i => i.Leads)
                .HasForeignKey(l => l.IntentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.TimeFrame)
                .WithMany(tm => tm.Leads)
                .HasForeignKey(l => l.TimeFrameId)
                .OnDelete(DeleteBehavior.Restrict);

          




            //indexes
            builder.HasIndex(l => l.LeadStatusId);


        }
    }
}
