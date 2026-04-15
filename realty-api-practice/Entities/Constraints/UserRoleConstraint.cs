using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using realty_api_practice.Entities.Common;

namespace realty_api_practice.Entities.Constraints
{
    public class UserRoleConstraint : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles");

            builder.HasKey(ur => ur.Id);
            builder.Property(ur => ur.Id)
                .ValueGeneratedOnAdd();

            builder.Property(ur => ur.UserId)
                .IsRequired();

            builder.Property(ur=> ur.RoleId)
                .IsRequired();

            builder.Property(ur => ur.Active)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ur => ur.Role)
                .WithMany(r=> r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(ur => new {ur.UserId, ur.RoleId})
                .IsUnique();


        }
    }
}
