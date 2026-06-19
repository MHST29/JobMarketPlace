using FluentAssertions;
using JobMarketPlace.Application.Features.JobOffer.Query.GetAllJobOffers;
using JobMarketPlace.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Test.JobOffer
{
    public class GetJobOffersQueryHandlerTest
    {
        [Fact]
        public async Task Handle_Should_Return_JobOffers()
        {
            // Arrange

            var jobOffers = new List<JobMarketPlace.Domain.Entities.JobOffer>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Price = 5,
                JobId = new Guid("a0203425-73da-4439-aeaa-15193951dd73"),
                ContractorId = new Guid("21c671e4-4b67-4cc0-9876-bd90c8dce28b"),
            },
                        new()
            {
                 Id = Guid.NewGuid(),
                Price = 5,
                JobId = new Guid("a0203425-73da-4439-aeaa-15193951dd73"),
                ContractorId = new Guid("21c671e4-4b67-4cc0-9876-bd90c8dce28b"),
            }
        };
            var options =
                new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(
                        Guid.NewGuid().ToString())
                    .Options;

            await using var context =
                new AppDbContext(options);

            context.JobOffers.AddRange(jobOffers);

            await context.SaveChangesAsync();

            var handler =
                new GetJobOffersQueryHandler(
                    context);

            // Act

            var result =
                await handler.Handle(
                    new GetJobOffersQuery(),
                    CancellationToken.None);

            // Assert

            result.Should().HaveCount(2);
        }
    }
}
