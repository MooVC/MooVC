namespace MooVC.Modelling;

using static System.IO.Path;

/// <summary>
/// Represents a file to be written by a modelling writer.
/// </summary>
/// <param name="Content">The file content.</param>
/// <param name="Extension">The file extension.</param>
/// <param name="Name">The file name without extension.</param>
/// <param name="Path">The file path relative to the output root.</param>
public sealed record File(string Content, string Extension, string Name, string Path)
{
    /// <summary>
    /// Gets the file name including the extension.
    /// </summary>
    public string FullName => string.Concat(Name, ".", Extension);

    /// <summary>
    /// Gets the file path including the file name.
    /// </summary>
    public string FullPath => Combine(Path, FullName);
}