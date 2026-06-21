using Application.Test.Common;
using FluentAssertions;
using JobMarketPlace.Application.Features.Job.Command.DeleteJob;
using JobMarketPlace.Application.Features.JobOffer.Command.DeleteJobOffer;
using JobMarketPlace.Domain.Entities;
using JobMarketPlace.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Test.JobOffer
{
    public class DeleteJobOfferCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Delete_JobOffer()
        {
            // Arrange

            var options =
                new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(
                    Guid.NewGuid().ToString())
                .Options;

            await using var context =
                new AppDbContext(options);


            var jobOffer = new JobMarketPlace.Domain.Entities.JobOffer
            {
                Id = Guid.NewGuid(),
                Price = 5,
                JobId = new Guid("a0203425-73da-4439-aeaa-15193951dd73"),
                ContractorId = new Guid("21c671e4-4b67-4cc0-9876-bd90c8dce28b"),
            };

            // Arrange
            context.JobOffers.Add(jobOffer);

            await context.SaveChangesAsync();

            var handler =
                new DeleteJobOfferCommandHandler(context);

            var command =
                new DeleteJobOfferCommand(jobOffer.Id);

            // Act
            var result = await handler.Handle(
                command,
                CancellationToken.None);

            // Assert
            result.Should().BeTrue();
        }
    }
}
