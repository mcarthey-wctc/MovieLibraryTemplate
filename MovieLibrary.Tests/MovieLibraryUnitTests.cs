using Microsoft.Extensions.Logging;
using Moq;
using MovieLibrary.Services;

namespace MovieLibrary.Tests
{
    public class MovieLibraryUnitTests
    {
        private const string TestFilePath = "Files/movies.csv";

        [Fact]
        public void Read_LogsError_WhenFileDoesNotExist()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<IFileService>>();
            var fileService = new FileService(loggerMock.Object, "nonexistent.csv");

            // Act
            fileService.Read();

            // Assert
            loggerMock.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.AtLeastOnce);
        }

        [Fact]
        public void Read_DoesNotLogError_WhenFileExists()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<IFileService>>();
            var fileService = new FileService(loggerMock.Object, TestFilePath);

            // Act
            fileService.Read();

            // Assert
            loggerMock.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Never);
        }

        [Fact]
        public void Write_LogsInformation_WhenMovieIsAdded()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<IFileService>>();
            var fileService = new FileService(loggerMock.Object, TestFilePath);
            var movieId = 1UL;
            var movieTitle = "Test Movie";
            var genres = new List<string> { "Action", "Adventure" };

            // Act
            fileService.Write(movieId, movieTitle, genres);

            // Assert
            loggerMock.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.AtLeastOnce);
        }
    }
}
