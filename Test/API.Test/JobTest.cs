using FluentAssertions;
using JobMarketPlace.Application.Features.Job.Query.GetAllJobs;
using JobMarketPlace.Domain.Entities;
using System.Net;
using System.Net.Http.Json;

namespace API.Test
{
    public class JobTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public JobTest(CustomWebApplicationFactory factory)
        {
            _client =
                factory.CreateClient();
        }

        [Fact]
        public async Task Create_Should_Return_201()
        {
            // Arrange

            var request = new
            {
                startDate = "2026-06-21",
                dueDate = "2026-06-30",
                budget = 10000,
                description = "New Job",
                customerId = Guid.NewGuid()
            };

            // Act

            var response =
                await _client.PostAsJsonAsync(
                    "/api/Jobs",
                    request);

            // Assert

            Assert.Equal(
                HttpStatusCode.Created,
                response.StatusCode);

            var result =
                await response.Content
                    .ReadFromJsonAsync<Job>();

            Assert.NotNull(result);
            Assert.NotEqual(Guid.Empty, result.Id);
        }

        [Fact]
        public async Task Get_Should_Return_200()
        {
            var response = await _client.GetAsync(
           "/api/Jobs");

            // Assert



            var jobs =
                await response.Content
                    .ReadFromJsonAsync<List<JobResponseDto>>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Update_Should_Return_200()
        {
            // ---------- Arrange ----------

            var createRequest = new
            {
                StartDate = "2026-06-21",

                DueDate = "2026-06-28",

                Budget = 5000,

                Description = "Original Job",

                CustomerId = Guid.NewGuid()
            };

            // Create a job

            var createResponse =
                await _client.PostAsJsonAsync(
                    "/api/jobs",
                    createRequest);

            createResponse.StatusCode
                .Should()
                .Be(HttpStatusCode.Created);

            var createdJob =
                await createResponse.Content
                    .ReadFromJsonAsync<Job>();

            // Update payload

            var updateRequest = new
            {
                StartDate = "2026-06-22",

                DueDate = "2026-07-05",

                Budget = 15000,

                Description = "Updated Job"
            };

            // ---------- Act ----------

            var updateResponse =
                await _client.PutAsJsonAsync(
                    $"/api/jobs/{createdJob!.Id}",
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
                StartDate = "2026-06-21",

                DueDate = "2026-06-28",

                Budget = 5000,

                Description =
                    "Delete Me",

                CustomerId =
                    Guid.NewGuid()
            };

            var createResponse =
                await _client.PostAsJsonAsync(
                    "/api/jobs",
                    createRequest);

            var created =
                await createResponse.Content
                    .ReadFromJsonAsync<Job>();

            // Act

            var response =
                await _client.DeleteAsync(
                    $"/api/jobs/{created!.Id}");

            // Assert

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.NoContent);
        }
    }
}

