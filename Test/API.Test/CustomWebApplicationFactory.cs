using JobMarketPlace.Domain.Entities;
using JobMarketPlace.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.Test
{
        public class CustomWebApplicationFactory
    : WebApplicationFactory<Program>
        {
            private SqliteConnection? _connection;

            protected override void ConfigureWebHost(
                IWebHostBuilder builder)
            {
                builder.ConfigureServices(services =>
                {
                    // Remove PostgreSQL DbContext

                    var descriptor =
                        services.SingleOrDefault(
                            d => d.ServiceType ==
                            typeof(DbContextOptions<AppDbContext>));

                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

                    // Create SQLite in-memory database

                    _connection =
                        new SqliteConnection(
                            "DataSource=:memory:");

                    _connection.Open();

                    services.AddDbContext<AppDbContext>(
                        options =>
                        {
                            options.UseSqlite(_connection);
                        });

                    // Build provider

                    var provider =
                        services.BuildServiceProvider();

                    using var scope =
                        provider.CreateScope();

                    var context =
                        scope.ServiceProvider
                            .GetRequiredService<AppDbContext>();

                    context.Database.EnsureCreated();

                    SeedData(context);
                });
            }

            private static void SeedData(
                AppDbContext context)
            {
                if (context.Jobs.Any())
                {
                    return;
                }

                context.Jobs.Add(
                    new Job
                    {
                        Id = Guid.NewGuid(),

                        StartDate =
                            DateOnly.FromDateTime(
                                DateTime.Today),

                        DueDate =
                            DateOnly.FromDateTime(
                                DateTime.Today.AddDays(7)),

                        Budget = 10000,

                        Description =
                            "Seeded Job",

                        CustomerId =
                            Guid.NewGuid()
                    });

                context.SaveChanges();
            }

            protected override void Dispose(
                bool disposing)
            {
                _connection?.Dispose();

                base.Dispose(disposing);
            }
        }
}
