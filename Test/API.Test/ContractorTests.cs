using FluentAssertions;
using JobMarketPlace.Domain.Entities;
using System.Net;
using System.Net.Http.Json;

namespace API.Test
{
    public class ContractorTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public ContractorTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Create_Should_Return_201()
        {
            // Arrange

            var request = new
            {
                name = "LaptopFactory",
                rating = 5
            };

            // Act

            var response =
                await _client.PostAsJsonAsync("/api/Contractors",
                    request);

            // Assert

            Assert.Equal(
             HttpStatusCode.Created,
             response.StatusCode);

            var result =
                await response.Content
                    .ReadFromJsonAsync<Contractor>();

            Assert.NotNull(result);
            Assert.NotEqual(Guid.Empty, result.Id);
        }
    }
}