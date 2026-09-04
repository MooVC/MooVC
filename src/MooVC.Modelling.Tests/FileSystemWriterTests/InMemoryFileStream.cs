namespace MooVC.Modelling.FileSystemWriterTests;

internal sealed class InMemoryFileStream
    : MemoryStream
{
    private readonly string _path;
    private readonly Dictionary<string, byte[]> _fileContents;

    public InMemoryFileStream(string path, int bufferSize, Dictionary<string, byte[]> fileContents)
        : base(bufferSize)
    {
        _path = path;
        _fileContents = fileContents;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _fileContents[_path] = ToArray();
        }

        base.Dispose(disposing);
    }
}