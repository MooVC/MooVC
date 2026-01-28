namespace MooVC.Modelling.FileSystemWriterTests;

internal sealed class InMemoryFileSystem
    : IFileSystem
{
    private readonly Dictionary<string, byte[]> _fileContents = new(StringComparer.Ordinal);

    public HashSet<string> CreatedDirectories { get; } = new(StringComparer.Ordinal);

    public void CreateDirectory(string path)
    {
        _ = CreatedDirectories.Add(path);
    }

    public Stream CreateFileStream(string path, int bufferSize)
    {
        return new InMemoryFileStream(path, bufferSize, _fileContents);
    }

    public string GetCurrentDirectory()
    {
        return Environment.CurrentDirectory;
    }

    public string? GetDirectoryName(string path)
    {
        return Path.GetDirectoryName(path);
    }

    public string GetFullPath(string path)
    {
        return Path.GetFullPath(path, Environment.CurrentDirectory);
    }

    public bool TryGetFileContent(string path, out byte[]? fileContent)
    {
        return _fileContents.TryGetValue(path, out fileContent);
    }
}