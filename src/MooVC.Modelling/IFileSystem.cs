namespace MooVC.Modelling;

using System.IO;

/// <summary>
/// Defines file system operations required by modelling writers.
/// </summary>
public interface IFileSystem
{
    /// <summary>
    /// Gets the current working directory.
    /// </summary>
    /// <returns>The current working directory.</returns>
    string GetCurrentDirectory();

    /// <summary>
    /// Creates a directory at the provided path.
    /// </summary>
    /// <param name="path">The directory path to create.</param>
    void CreateDirectory(string path);

    /// <summary>
    /// Creates a writable file stream at the provided path.
    /// </summary>
    /// <param name="path">The file path to create.</param>
    /// <param name="bufferSize">The buffer size to use.</param>
    /// <returns>The file stream.</returns>
    Stream CreateFileStream(string path, int bufferSize);

    /// <summary>
    /// Gets the directory name for the provided path.
    /// </summary>
    /// <param name="path">The path to evaluate.</param>
    /// <returns>The directory name, if available.</returns>
    string? GetDirectoryName(string path);

    /// <summary>
    /// Gets the full path for the provided path.
    /// </summary>
    /// <param name="path">The path to resolve.</param>
    /// <returns>The full path.</returns>
    string GetFullPath(string path);
}