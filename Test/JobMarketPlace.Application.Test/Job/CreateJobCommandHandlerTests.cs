using FluentAssertions;
using JobMarketPlace.Application.Common.Interfaces;
using JobMarketPlace.Application.Features.Job.Command.CreateJob;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;

namespace JobMarketPlace.Application.Test.Job
{
   public class CreateJobCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Create_Job()
        {
            // Arrange

            var contractors = new List<Domain.Entities.Job>();

            var mockContext = new Mock<IAppDbContext>();

            mockContext.Setup(x => x.Jobs)
                .ReturnsDbSet(contractors);

            mockContext.Setup(x => x.SaveChangesAsync(
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var handler =
                new CreateJobCommandHandler(
                    mockContext.Object);
            var command = new CreateJobCommand(
                new DateOnly(2024, 5, 10),
                new DateOnly(2024, 5, 10),
                120000,
                "Test Job",
                new Guid("a0203425-73da-4439-aeaa-15193951dd73"),
                new Guid("21c671e4-4b67-4cc0-9876-bd90c8dce28b"));

            // Act

            var result = await handler.Handle(
                command,
                CancellationToken.None);

            // Assert

            result.Should().NotBeEmpty();

            mockContext.Verify(x =>
                x.SaveChangesAsync(
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}
