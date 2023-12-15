using CleanArchitecture.Persistence.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CleanArchitectureSpecFlow.Support
{
    public class WebAppFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                //get the data context of the main application
                var dbContextDescriptor = services.SingleOrDefault(
                    db => db.ServiceType == typeof(DbContextOptions<DataContext>));
                
                //remove the main application dbcontext the service
                if(dbContextDescriptor != null)
                {
                    services.Remove(dbContextDescriptor);
                }

                //add the test dbcontext to the service instead
                services.AddDbContext<DataContext>(options =>
                {
                    options.UseInMemoryDatabase("TestDb");
                },ServiceLifetime.Singleton);

                //build the service provider
                var serviceProvider=services.BuildServiceProvider();
                
                // Create a scope to obtain a reference to the database
                using var scope=serviceProvider.CreateScope();
                
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<WebAppFactory<TProgram>>>();

                // Ensure the database is created.
                db.Database.EnsureCreated();

                try
                {
                    // Seed the database with test data.
                    db.InitializeTestDatabase();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"An error occurred seeding the database with test data messages.Error: {ex.Message}");
                }

            });
        }
    }
}
