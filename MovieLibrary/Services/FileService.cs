using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;

namespace MovieLibrary.Services;

/// <summary>
///     This concrete service and method only exists an example.
///     It can either be copied and modified, or deleted.
/// </summary>
public class FileService : IFileService
{
    private readonly ILogger<IFileService> _logger;
    private readonly string _file;

    public FileService(ILogger<IFileService> logger)
    {
        _logger = logger;
        _file = $"{Environment.CurrentDirectory}/Files/movies.csv";
    }

    // Additional constructor for testing
    public FileService(ILogger<IFileService> logger, string filePath)
    {
        _logger = logger;
        _file = filePath;
    }

    public void Read()
    {
        if (!File.Exists(_file))
        {
            _logger.Log(LogLevel.Error, $"File does not exist: {_file}");
            return;
        }

        // Check if the file is empty
        if (new FileInfo(_file).Length == 0)
        {
            _logger.Log(LogLevel.Information, $"File is empty: {_file}");
            return;
        }

        List<UInt64> MovieIds = new List<UInt64>();
        List<string> MovieTitles = new List<string>();
        List<string> MovieGenres = new List<string>();

        // TODO should use List<Movie> movies = new List<Movie>();

        try
        {
            using (StreamReader sr = new StreamReader(_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null) // Read a new line at each iteration
                {
                    // Process the line...
                }
            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex.Message);
        }

        _logger.Log(LogLevel.Information, $"Movies in file {MovieIds.Count}");
    }

    public void Write(UInt64 movieId, string movieTitle, List<string> genres)
    {
        try
        {
            // Rest of the code...

            using (StreamWriter sw = new StreamWriter(_file, true))
            {
                string genresString = string.Join("|", genres); // Note this is not complete
                sw.WriteLine($"{movieId},{movieTitle},{genresString}");
            }

            _logger.Log(LogLevel.Information, $"Movie id {movieId} added");
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex.Message);
        }
    }

}
