using JobMarketPlace.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Application.Test.Common
{
    public static class DbContextJobOfferMockFactory
    {
        public static Mock<IAppDbContext>
            Create(JobMarketPlace.Domain.Entities.JobOffer jobOffer)
        {
            var jobOffers = new List<JobMarketPlace.Domain.Entities.JobOffer>
        {
            jobOffer
        }.AsQueryable();

            var mockSet =
                new Mock<DbSet<JobMarketPlace.Domain.Entities.JobOffer>>();

            var context =
                new Mock<IAppDbContext>();

            context.Setup(x => x.JobOffers)
                .Returns(mockSet.Object);

            context.Setup(x =>
                x.SaveChangesAsync(
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            return context;
        }
    }

    public static class DbContextJobMockFactory
    {
        public static Mock<IAppDbContext>
            Create(JobMarketPlace.Domain.Entities.Job job)
        {
            var jobs = new List<JobMarketPlace.Domain.Entities.Job>
        {
            job
        }.AsQueryable();

            var mockSet =
                new Mock<DbSet<JobMarketPlace.Domain.Entities.Job>>();

            var context =
                new Mock<IAppDbContext>();

            context.Setup(x => x.Jobs)
                .Returns(mockSet.Object);

            context.Setup(x =>
                x.SaveChangesAsync(
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            return context;
        }
    }
}
