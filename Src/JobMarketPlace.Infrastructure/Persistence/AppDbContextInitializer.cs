using JobMarketPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMarketPlace.Infrastructure.Persistence
{
    public class AppDbContextInitializer
    {
        public static async Task SeedAsync(
        AppDbContext context)
        {
            await context.Database.MigrateAsync();

            if (await context.Customers.AnyAsync())
            {
                return;
            }

            var customers = new List<Customer>
        {
            new()
            {
                Id = Guid.NewGuid(),
                FirstName = "Dell",
                LastName = "Laptop"
            },

            new()
            {
                Id = Guid.NewGuid(),
                FirstName = "Mac",
                LastName = "Laptop"
            }
        };
            var contractors = new List<Contractor>
            { 
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "LJ Capital Inc.",
                    Rating = 3
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Capital City Inc.",
                    Rating = 3
                }

            };


            await context.Customers.AddRangeAsync(customers);
            await context.Contractors.AddRangeAsync(contractors);

            await context.SaveChangesAsync();
        }
    }
}
