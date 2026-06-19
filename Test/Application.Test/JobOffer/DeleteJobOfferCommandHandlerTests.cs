using Application.Test.Common;
using FluentAssertions;
using JobMarketPlace.Application.Features.Job.Command.DeleteJob;

namespace Application.Test.JobOffer
{
    public class DeleteJobOfferCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Delete_JobOffer()
        {


            var jobOffer = new JobMarketPlace.Domain.Entities.JobOffer
            {
                Id = Guid.NewGuid(),
                Price = 5,
                JobId = new Guid("a0203425-73da-4439-aeaa-15193951dd73"),
                ContractorId = new Guid("21c671e4-4b67-4cc0-9876-bd90c8dce28b"),
            };

            // Arrange
            var dbContext = DbContextJobOfferMockFactory.Create(jobOffer);


            var handler =
                new DeleteJobCommandHandler(
                    dbContext.Object);

            var command =
                new DeleteJobCommand(jobOffer.Id);

            // Act
            var result = await handler.Handle(
                command,
                CancellationToken.None);

            // Assert
            result.Should().BeTrue();
        }
    }
}
