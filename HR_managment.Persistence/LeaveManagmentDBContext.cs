
using HR_Managment.Domain;
using HR_Managment.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HR_managment.Persistence
{
    public class LeaveManagmentDBContext : DbContext
    {
   
        public LeaveManagmentDBContext(DbContextOptions<LeaveManagmentDBContext> contextOptions)
        : base(contextOptions)
        {

        }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagmentDBContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entity in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entity.Entity.DateUpdated = DateTime.Now;
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        public override int SaveChanges()
        {
            foreach (var entity in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entity.Entity.DateUpdated = DateTime.Now;
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
