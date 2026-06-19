using FluentAssertions;
using JobMarketPlace.Domain.Entities;
using Xunit;

namespace JobMarketPlace.Domain.Test
{
    public class JobOfferTests
    {
        [Fact]
        public void JobOffer_Should_Be_Created()
        {
            var jobOffer = new JobOffer
            {
                JobId = new Guid("21c671e4-4b67-4cc0-9876-bd90c8dce28b"),
                ContractorId = new Guid("a0203425-73da-4439-aeaa-15193951dd73"),
                Price = 10
            };

            jobOffer.Price.Should().Be(10);
            jobOffer.ContractorId.Should().Be(new Guid("a0203425-73da-4439-aeaa-15193951dd73"));
            jobOffer.JobId.Should().Be(new Guid("21c671e4-4b67-4cc0-9876-bd90c8dce28b"));
        }
    }
}
