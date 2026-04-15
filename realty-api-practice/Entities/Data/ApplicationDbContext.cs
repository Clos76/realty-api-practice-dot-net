using Microsoft.EntityFrameworkCore;

using realty_api_practice.Entities.Common;
using System.Reflection;

namespace realty_api_practice.Entities.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //automatically loads all ientityconfiguarations classes
        }

        // Add-Migration <name>
        // update-database
        // Remove-Migration
        // update-database <name> to update with this migration
        // Script-Migration -From 20190101011200_Initial-Migration -To 20190101021200_Migration-2
        // get-migrations


        // aseguras-migration consider entity in db
        //catalogo de todas tablas. -- constraints, etc. 


        //core tables -- 
        public DbSet<City> Cities => Set<City>();
        public DbSet<LegalStatus> LegalStatuses => Set<LegalStatus>();
        public DbSet<ListingSource> ListingSources => Set<ListingSource>();
        public DbSet<Property> Properties => Set<Property>();
        public DbSet<PropertyImage> PropertyImages => Set<PropertyImage>();
        public DbSet<PropertyType> PropertyTypes => Set<PropertyType>();
        public DbSet<State> States => Set<State>();

        // leads
        public DbSet<Lead> Leads => Set<Lead>();
        public DbSet<LeadStatus> LeadStatuses => Set<LeadStatus>();
        public DbSet<LeadSource> LeadSources => Set<LeadSource>();
        public DbSet<Intent> Intents => Set<Intent>();
        public DbSet<TimeFrame> TimeFrames => Set<TimeFrame>();
        public DbSet<LeadAssignment> LeadAssignments => Set<LeadAssignment>();
        public DbSet<User> Users => Set<User>();

        //users
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<PropertyView> PropertyViews => Set<PropertyView>();
        public DbSet<PropertyAssignment> PropertyAssignments => Set<PropertyAssignment>();



    }
}
