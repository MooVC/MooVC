namespace MooVC.Modelling;

using static System.IO.Path;

public sealed record File(string Content, string Extension, string Name, string Path)
{
    public string FileName => string.Concat(Name, ".", Extension);

    public string FilePath => Combine(Path, FileName);
}