using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransportSystem.Core.Entities;
using TransportSystem.Data.Extensions;

namespace TransportSystem.Data.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    
            modelBuilder.ApplyAllConfigurations<ApplicationDbContext>();
            modelBuilder.ConfigureDeletableEntities();
        }

        private const string IsDeletedProperty = "IsDeleted";

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues[IsDeletedProperty] = false;
                        break;
                    case EntityState.Modified:
                        entry.CurrentValues[IsDeletedProperty] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues[IsDeletedProperty] = true;
                        break;
                }
            }
        }

          public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateSoftDeleteStatuses();
            this.AddAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }

        DbSet<Booking> Bookings {get; set;}
        DbSet<Bus> Buses {get; set;}
        DbSet<Trip> Trips {get; set;}
        DbSet<Passenger> Passengers {get; set;}
    }
}