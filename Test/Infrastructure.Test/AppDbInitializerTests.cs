using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using JobMarketPlace.Infrastructure.Persistence;

namespace Infrastructure.Test
{
    public class AppDbInitializerTests
    {
        [Fact]
        public async Task Seed_Should_Insert_Data()
        {
            var options =
                new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(
                    Guid.NewGuid().ToString())
                .Options;

            await using var context =
                new AppDbContext(options);

            await AppDbContextInitializer.SeedAsync(
                context);

            context.Customers.Count()
                .Should()
                .BeGreaterThan(0);
        }
    }
}
