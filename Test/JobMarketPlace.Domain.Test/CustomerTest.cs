using FluentAssertions;
using JobMarketPlace.Domain.Entities;
using Xunit;

namespace JobMarketPlace.Domain.Test
{
    public class CustomerTest
    {
        [Fact]
        public void Customer_Should_Be_Created()
        {
            var jobOffer = new Customer
            {
                FirstName = "Test FirstName",
                LastName = "Test LastName"
            };

            jobOffer.FirstName.Should().Be("Test FirstName");
            jobOffer.LastName.Should().Be("Test LastName");
        }
    }
}
