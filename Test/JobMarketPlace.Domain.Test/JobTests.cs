using FluentAssertions;
using JobMarketPlace.Domain.Entities;
using Xunit;

namespace JobMarketPlace.Domain.Test
{
    public class JobTests
    {
        [Fact]
        public void Job_Should_Be_Created()
        {
            var contractor = new Job
            {
                StartDate = new DateOnly(2024, 5, 10),
                DueDate = new DateOnly(2024, 5, 10),
                Budget = 120000,
                Description = "TestDescription",
                AcceptedJobOfferId = new Guid("a0203425-73da-4439-aeaa-15193951dd73"),
                CustomerId = new Guid("21c671e4-4b67-4cc0-9876-bd90c8dce28b")
            };

            contractor.StartDate.Should().Be(new DateOnly(2024, 5, 10));
            contractor.DueDate.Should().Be(new DateOnly(2024, 5, 10));
            contractor.Budget.Should().Be(120000);
            contractor.Description.Should().Be("TestDescription");
            contractor.AcceptedJobOfferId.Should().Be(new Guid("a0203425-73da-4439-aeaa-15193951dd73"));
            contractor.CustomerId.Should().Be(new Guid("21c671e4-4b67-4cc0-9876-bd90c8dce28b"));
        }
    }
}
