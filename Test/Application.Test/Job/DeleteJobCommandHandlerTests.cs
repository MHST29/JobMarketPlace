using Application.Test.Common;
using FluentAssertions;
using JobMarketPlace.Application.Common.Interfaces;
using JobMarketPlace.Application.Features.Job.Command.DeleteJob;
using JobMarketPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Test.Job
{
    public class DeleteJobCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Delete_Job()
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

            // Arrange
            var dbContext = DbContextJobMockFactory.Create(job);

            
            var handler =
                new DeleteJobCommandHandler(
                    dbContext.Object);

            var command =
                new DeleteJobCommand(job.Id);

            // Act
            var result = await handler.Handle(
                command,
                CancellationToken.None);

            // Assert
            result.Should().BeTrue();
        }
    }
}
