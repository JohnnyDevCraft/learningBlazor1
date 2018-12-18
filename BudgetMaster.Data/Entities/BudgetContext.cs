using BudgetMaster.Data.Entities.Access;
using BudgetMaster.Data.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace BudgetMaster.Data.Entities
{
    public class BudgetContext: DbContext
    {

        public DbSet<Group> Groups { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<GroupAccess> GroupAccesses { get; set; }
        
        
        public BudgetContext(DbContextOptions<BudgetContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var mb = modelBuilder;

            mb.Entity<Group>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasMany(x => x.Accesses).WithOne(x => x.Group).HasForeignKey(x => x.GroupId);
                e.HasOne(x => x.CreatedBy).WithMany(x => x.OwnedGroups).HasForeignKey(x => x.CreatedById);
            });

            mb.Entity<Profile>(e =>
            {
                e.HasMany(x => x.Accesses).WithOne(x => x.Profile).HasForeignKey(x => x.ProfileId);
                e.OwnsOne(x => x.BillingAddress);
                e.OwnsOne(x => x.MainPhone);
                e.OwnsOne(x => x.PhysicalAddress);
            });

            mb.Owned<Address>();
            mb.Owned<Phone>();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}