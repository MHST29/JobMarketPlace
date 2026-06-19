using FluentAssertions;
using System.Net;
using System.Net.Http.Json;

namespace API.Test
{
    public class JobOfferTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public JobOfferTest(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Create_Should_Return_201()
        {
            // Arrange

            var request = new
            {
                name = "Laptop",
                description = "Gaming Laptop",
                price = 65000,
                quantity = 10
            };

            // Act

            var response =
                await _client.PostAsJsonAsync("/api/contractor",
                    request);

            // Assert

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task Get_Should_Return_200()
        {
            // Act

            var response =
                await _client.GetAsync(
                    "/api/products");

            // Assert

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Update_Should_Return_204()
        {
            // Arrange

            var id = "existing-guid";

            var request = new
            {
                name = "Laptop Updated",

                description = "Gaming",

                price = 70000,

                quantity = 20
            };

            // Act

            var response =
                await _client.PutAsJsonAsync(
                    $"/api/products/{id}",
                    request);

            // Assert

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Delete_Should_Return_204()
        {
            // Arrange

            var id = "existing-guid";

            // Act

            var response =
                await _client.DeleteAsync(
                    $"/api/products/{id}");

            // Assert

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.NoContent);
        }
    }
}
