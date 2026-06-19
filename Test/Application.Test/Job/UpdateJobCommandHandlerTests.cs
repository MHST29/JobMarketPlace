using Application.Test.Common;
using FluentAssertions;
using JobMarketPlace.Application.Common.Interfaces;
using JobMarketPlace.Application.Features.Job.Command.UpdateJob;
using Moq;

namespace Application.Test.Job
{
    public class UpdateJobCommandHandlerTests
    {
        [Fact]
        public async Task Should_Update_Job()
        {
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

            var db = DbContextJobMockFactory.Create(job);

            var handler =
                new UpdateJobCommandHandler(
                    db.Object);

            var command =
                new UpdateJobCommand(
                    Guid.NewGuid(),
             new DateOnly(2024, 5, 10),
                new DateOnly(2024, 5, 10),
                120000,
                "Test Job",
                new Guid("a0203425-73da-4439-aeaa-15193951dd73"),
                new Guid("21c671e4-4b67-4cc0-9876-bd90c8dce28b"));

            var result =
                await handler.Handle(
                    command,
                    CancellationToken.None);

            result.Should().Be(job.Id);

            job.Budget.Should().Be(120000);
            job.AcceptedJobOfferId.Should().Be(new Guid("a0203425-73da-4439-aeaa-15193951dd73"));
            job.CustomerId.Should().Be(new Guid("21c671e4-4b67-4cc0-9876-bd90c8dce28b"));
        }
    }
}
