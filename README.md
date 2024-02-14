# Movie Library Application Development

We are embarking on creating a Movie Library application. This project involves working with an initial movie data file, specifically `movies.csv`.

## Key Features and Implementations

### 1. **List All Movies in the File**
- **Efficient Display**: Implement a user-friendly way to list movies without just scrolling through all entries. Consider using a NuGet package like `ConsolePager` for smart pagination.

### 2. **Add Movies to the File**
- **Unique IDs**: Ensure that duplicate IDs are not entered. Implement logic to determine the next appropriate `movieId` for new entries.
- **No Duplicate Titles**: Prevent the addition of movies with titles that exactly match existing entries.

## Development Considerations

- **Exception Handling**: Robustly manage exceptions to ensure application stability.
- **Architecture**: Contemplate the creation of additional classes and methods to maintain a clean and modular codebase.
- **Logging**: Integrate a logging framework to facilitate debugging and monitoring.
- **Testing**: Include at least one unit test to validate your application's functionality.
