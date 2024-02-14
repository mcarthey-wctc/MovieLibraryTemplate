using System.Collections.Generic;
using System;

namespace MovieLibrary.Services;

/// <summary>
///     This service interface only exists an example.
///     It can either be copied and modified, or deleted.
/// </summary>
public interface IFileService
{
    void Read();
    void Write(UInt64 movieId, string movieTitle, List<string> genres);
}
