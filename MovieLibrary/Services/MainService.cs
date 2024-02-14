using System;
using System.Collections.Generic;

namespace MovieLibrary.Services;

/// <summary>
///     You would need to inject your interfaces here to execute the methods in Invoke()
///     See the commented out code as an example
/// </summary>
public class MainService : IMainService
{
    private readonly IFileService _fileService;
    public MainService(IFileService fileService)
    {
        _fileService = fileService;
    }

    public void Invoke()
    {
        string choice;
        do
        {
            Console.WriteLine("1) Add Movie");
            Console.WriteLine("2) Display All Movies");
            Console.WriteLine("X) Quit");
            choice = Console.ReadLine();

            // Logic would need to exist to validate inputs and data prior to writing to the file
            // You would need to decide where this logic would reside.
            // Is it part of the FileService or some other service?
            if (choice == "1")
            {
                // Ask user to input movie id
                Console.WriteLine("Enter the movie id");
                UInt64 movieId = UInt64.Parse(Console.ReadLine());

                // Ask user to input movie title
                Console.WriteLine("Enter the movie title");
                string movieTitle = Console.ReadLine();

                // Input genres
                List<string> genres = new List<string>();
                string genre;
                do
                {
                    // Ask user to enter genre
                    Console.WriteLine("Enter genre (or done to quit)");
                    genre = Console.ReadLine();
                    // If user enters "done" or does not enter a genre do not add it to list
                    if (genre != "done" && genre.Length > 0)
                    {
                        genres.Add(genre);
                    }
                } while (genre != "done");

                _fileService.Write(movieId, movieTitle, genres);
            }
            else if (choice == "2")
            {
                _fileService.Read();
            }
        }
        while (choice != "X");
    }
}
