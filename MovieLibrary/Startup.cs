// Import necessary namespaces
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MovieLibrary.Services;

// Define the namespace for the current file
namespace MovieLibrary
{
    /// <summary>
    ///     Used for registration of new interfaces
    /// </summary>
    internal class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            // Create a new instance of ServiceCollection
            // ServiceCollection is a default implementation of IServiceCollection
            IServiceCollection services = new ServiceCollection();

            // Configure logging services for the application
            services.AddLogging(builder =>
            {
                // Add a console logger
                builder.AddConsole();

                // Add a file logger
                builder.AddFile("app.log");
            });

            // Register your services here
            // Transient services are created each time they're requested from the service container
            // Add new lines of code here to register any interfaces and concrete services you create
            services.AddTransient<IMainService, MainService>();
            services.AddTransient<IFileService, FileService>();

            // Build the service provider from the service collection
            return services.BuildServiceProvider();
        }
    }
}
