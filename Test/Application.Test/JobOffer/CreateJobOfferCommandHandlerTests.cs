using FluentAssertions;
using JobMarketPlace.Application.Common.Interfaces;
using JobMarketPlace.Application.Features.JobOffer.Command.CreateJobOffer;
using Moq;
using Moq.EntityFrameworkCore;

namespace Application.Test.JobOffer
{
    public class CreateJobOfferCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Create_JobOffer()
        {
            // Arrange

            var contractors = new List<JobMarketPlace.Domain.Entities.JobOffer>();

            var mockContext = new Mock<IAppDbContext>();

            mockContext.Setup(x => x.JobOffers)
                .ReturnsDbSet(contractors);

            mockContext.Setup(x => x.SaveChangesAsync(
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var handler =
                new CreateJobOfferCommandHandler(
                    mockContext.Object);

            var command = new CreateJobOfferCommand(
                5,
                Guid.NewGuid(),
                Guid.NewGuid());

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
