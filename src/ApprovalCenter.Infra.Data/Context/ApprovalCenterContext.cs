using ApprovalCenter.Domain.Approval.Entities;
using ApprovalCenter.Domain.Category.Entities;
using ApprovalCenter.Infra.Data.ContextConfiguration;
using Microsoft.EntityFrameworkCore;

namespace ApprovalCenter.Infra.Data.Context
{
    public class ApprovalCenterContext : DbContext
    {
        public DbSet<ApprovalEntity> Approval { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }

        public ApprovalCenterContext(DbContextOptions<ApprovalCenterContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApprovalContextConfiguration()); 
            modelBuilder.ApplyConfiguration(new CategoryContextConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApprovalCenterContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
