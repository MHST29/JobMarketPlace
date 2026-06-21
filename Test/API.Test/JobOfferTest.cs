using FluentAssertions;
using JobMarketPlace.Application.Features.Job.Query.GetAllJobs;
using JobMarketPlace.Application.Features.JobOffer.Query.GetAllJobOffers;
using JobMarketPlace.Domain.Entities;
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
                JobId = Guid.NewGuid(),
                ContractorId = Guid.NewGuid(),
                Price = 65000
            };

            // Act

            var response =
                await _client.PostAsJsonAsync("/api/JobOffers",
                    request);

            // Assert

            Assert.Equal(
              HttpStatusCode.Created,
              response.StatusCode);

            var result =
                await response.Content
                    .ReadFromJsonAsync<JobOffer>();

            Assert.NotNull(result);
            Assert.NotEqual(Guid.Empty, result.Id);
        }

        [Fact]
        public async Task Get_Should_Return_200()
        {
            // Act

            var response =
                await _client.GetAsync(
                    "/api/JobOffers");

            // Assert

            var jobs =
                 await response.Content
                     .ReadFromJsonAsync<List<JobOfferResponseDto>>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Update_Should_Return_204()
        {
            /// Arrange

            var createRequest = new
            {
                JobId = Guid.NewGuid(),
                ContractorId = Guid.NewGuid(),
                Price = 65000
            };

            var createResponse =
                await _client.PostAsJsonAsync(
                    "/api/JobOffers",
                    createRequest);

            var created =
                await createResponse.Content
                    .ReadFromJsonAsync<Job>();


            // Assert

            var updateRequest = new
            {
                JobId = Guid.NewGuid(),
                ContractorId = Guid.NewGuid(),
                Price = 65000
            };

            // ---------- Act ----------

            var updateResponse =
                await _client.PutAsJsonAsync(
                    $"/api/JobOffers/{createRequest!.JobId}",
                    updateRequest);

            // ---------- Assert ----------

            updateResponse.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }
            
        [Fact]
        public async Task Delete_Should_Return_204()
        {
            // Arrange

            var createRequest = new
            {
                JobId = Guid.NewGuid(),
                ContractorId = Guid.NewGuid(),
                Price = 65000
            };

            var createResponse =
                await _client.PostAsJsonAsync(
                    "/api/JobOffers",
                    createRequest);

            var created =
                await createResponse.Content
                    .ReadFromJsonAsync<Job>();

            // Act

            var response =
                await _client.DeleteAsync(
                    $"/api/JobOffers/{created!.Id}");

            // Assert

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.NoContent);
        }
    }
}
