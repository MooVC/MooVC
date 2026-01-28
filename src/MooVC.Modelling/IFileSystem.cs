namespace MooVC.Modelling;

using System.IO;

public interface IFileSystem
{
    string GetCurrentDirectory();

    void CreateDirectory(string path);

    Stream CreateFileStream(string path, int bufferSize);

    string? GetDirectoryName(string path);

    string GetFullPath(string path);
}