using JobMarketPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace JobMarketPlace.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Contractor> Contractors { get; }

        DbSet<Customer> Customers { get; }

        DbSet<Job> Jobs { get; }

        DbSet<JobOffer> JobOffers { get; }

        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default);
    }
}
