namespace MooVC.Modelling;

using System.IO;

public sealed class FileSystem
    : IFileSystem
{
    public string GetCurrentDirectory()
    {
        return Directory.GetCurrentDirectory();
    }

    public void CreateDirectory(string path)
    {
        _ = Directory.CreateDirectory(path);
    }

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

    public string? GetDirectoryName(string path)
    {
        return Path.GetDirectoryName(path);
    }

    public string GetFullPath(string path)
    {
        return Path.GetFullPath(path);
    }
}