using Microsoft.EntityFrameworkCore;
using ApprovalCenter.Domain.Core.Events;
using ApprovalCenter.Infra.Data.ContextConfiguration;

namespace ApprovalCenter.Infra.Data.Context
{
    public class EventStoreSQLContext : DbContext
    {
        public DbSet<StoredEvent> StoredEvent { get; set; }

        public EventStoreSQLContext(DbContextOptions<EventStoreSQLContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventContextConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventStoreSQLContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
