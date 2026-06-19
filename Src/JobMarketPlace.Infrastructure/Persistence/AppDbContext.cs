using JobMarketPlace.Application.Common.Interfaces;
using JobMarketPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace JobMarketPlace.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Contractor> Contractors => Set<Contractor>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Job> Jobs => Set<Job>();
        public DbSet<JobOffer> JobOffers => Set<JobOffer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply all EntityTypeConfiguration classes automatically
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AppDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}