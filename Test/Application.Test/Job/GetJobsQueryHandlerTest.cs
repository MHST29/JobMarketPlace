using FluentAssertions;
using JobMarketPlace.Application.Features.Job.Query.GetAllJobs;
using JobMarketPlace.Application.Features.JobOffer.Query.GetAllJobOffers;
using JobMarketPlace.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Test.Job
{
    public class GetJobsQueryHandlerTest
    {
        [Fact]
        public async Task Handle_Should_Return_Jobs()
        {
            // Arrange

            var job = new JobMarketPlace.Domain.Entities.Job
            {
                Id = Guid.NewGuid(),
                StartDate = new DateOnly(2024, 5, 10),
                DueDate = new DateOnly(2024, 5, 10),
                Budget = 120000,
                Description = "Test Job",
                AcceptedJobOfferId = new Guid("a0203425-73da-4439-aeaa-15193951dd73"),
                CustomerId = new Guid("21c671e4-4b67-4cc0-9876-bd90c8dce28b")
            };
            var options =
                new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(
                        Guid.NewGuid().ToString())
                    .Options;

            await using var context =
                new AppDbContext(options);

            context.Jobs.Add(job);

            await context.SaveChangesAsync();

            var handler =
                new GetJobsQueryHandler(
                    context);

            // Act

            var result =
                await handler.Handle(
                    new GetJobsQuery(),
                    CancellationToken.None);

            // Assert

            result.Should().HaveCount(1);
        }
    }
}
