// Import necessary namespaces
using System;
using Microsoft.Extensions.DependencyInjection;
using MovieLibrary.Services;

// Define the namespace for the current file
namespace MovieLibrary
{
    public class Program
    {
        /// <summary>
        /// The Main method is the entry point for the application. 
        /// It is unlikely you will need to update this.
        /// </summary>
        /// <param name="args">Command line arguments passed to the application</param>
        private static void Main(string[] args)
        {
            try
            {
                // Create an instance of the Startup class
                var startup = new Startup();

                // Call ConfigureServices method of the Startup class to register services
                // and configure the application's service container
                var serviceProvider = startup.ConfigureServices();

                // Get an instance of IMainService from the service provider
                // This is an example of Dependency Injection
                var service = serviceProvider.GetService<IMainService>();

                // Call the Invoke method of the service
                // The '?' before '.Invoke()' is a null-conditional operator - it checks if 'service' is not null before calling Invoke
                service?.Invoke();
            }
            catch (Exception e)
            {
                // If any exceptions are thrown in the try block, they are caught here and written to the console
                Console.Error.WriteLine(e);
            }
        }
    }
}
