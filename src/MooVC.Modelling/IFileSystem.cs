namespace MooVC.Modelling;

using System.IO;

internal interface IFileSystem
{
    void CreateDirectory(string path);

    Stream CreateFileStream(string path, int bufferSize);

    string GetCurrentDirectory();

    string? GetDirectoryName(string path);

    string GetFullPath(string path);
}