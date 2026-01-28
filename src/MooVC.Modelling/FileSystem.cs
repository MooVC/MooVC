namespace MooVC.Modelling;

using System.IO;

/// <summary>
/// Provides file system operations for modelling writers.
/// </summary>
public sealed class FileSystem
    : IFileSystem
{
    /// <summary>
    /// Gets the current working directory.
    /// </summary>
    /// <returns>The current working directory.</returns>
    public string GetCurrentDirectory()
    {
        return Directory.GetCurrentDirectory();
    }

    /// <summary>
    /// Creates a directory at the provided path.
    /// </summary>
    /// <param name="path">The directory path to create.</param>
    public void CreateDirectory(string path)
    {
        _ = Directory.CreateDirectory(path);
    }

    /// <summary>
    /// Creates a writable file stream at the provided path.
    /// </summary>
    /// <param name="path">The file path to create.</param>
    /// <param name="bufferSize">The buffer size to use.</param>
    /// <returns>The file stream.</returns>
    public Stream CreateFileStream(string path, int bufferSize)
    {
        return new FileStream(
            path,
            FileMode.Create,
            FileAccess.Write,
            FileShare.None,
            bufferSize: bufferSize,
            useAsync: true);
    }

    /// <summary>
    /// Gets the directory name for the provided path.
    /// </summary>
    /// <param name="path">The path to evaluate.</param>
    /// <returns>The directory name, if available.</returns>
    public string? GetDirectoryName(string path)
    {
        return Path.GetDirectoryName(path);
    }

    /// <summary>
    /// Gets the full path for the provided path.
    /// </summary>
    /// <param name="path">The path to resolve.</param>
    /// <returns>The full path.</returns>
    public string GetFullPath(string path)
    {
        return Path.GetFullPath(path);
    }
}