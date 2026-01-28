namespace MooVC.Modelling;

using System.IO;

internal sealed class SystemFileSystem
    : IFileSystem
{
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

    public string GetCurrentDirectory()
    {
        return Directory.GetCurrentDirectory();
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