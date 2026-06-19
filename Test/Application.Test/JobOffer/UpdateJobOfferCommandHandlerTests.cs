using Application.Test.Common;
using FluentAssertions;
using JobMarketPlace.Application.Common.Interfaces;
using JobMarketPlace.Application.Features.JobOffer.Command.UpdateJobOffer;
using Moq;

namespace Application.Test.JobOffer
{
    public class UpdateJobOfferCommandHandlerTests
    {
        [Fact]
        public async Task Should_Update_JobOffer()
        {
            var jobOffer = new JobMarketPlace.Domain.Entities.JobOffer
            {
                Id = Guid.NewGuid(),
                Price = 5,
                JobId = new Guid("a0203425-73da-4439-aeaa-15193951dd73"),
                 ContractorId = new Guid("21c671e4-4b67-4cc0-9876-bd90c8dce28b"),
            };

            var db = DbContextJobOfferMockFactory.Create(jobOffer);

            var handler =
                new UpdateJobOfferCommandHandler(
                    db.Object);

            var command =
                new UpdateJobOfferCommand(
                    jobOffer.Id,
                    5,
                     new Guid("a0203425-73da-4439-aeaa-15193951dd73"),
                    new Guid("21c671e4-4b67-4cc0-9876-bd90c8dce28b"));

            var result =
                await handler.Handle(
                    command,
                    CancellationToken.None);

            result.Should().Be(jobOffer.Id);

            jobOffer.JobId.Should().Be(new Guid("a0203425-73da-4439-aeaa-15193951dd73"));

            jobOffer.Price.Should().Be(1000);

            jobOffer.ContractorId.Should().Be(new Guid("21c671e4-4b67-4cc0-9876-bd90c8dce28b"));
        }
    }
}
