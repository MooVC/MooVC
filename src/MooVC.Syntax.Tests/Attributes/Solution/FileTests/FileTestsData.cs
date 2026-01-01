namespace MooVC.Syntax.Attributes.Solution.FileTests;

using MooVC.Syntax.Elements;

internal static class FileTestsData
{
    public const string DefaultId = "FileId";
    public const string DefaultName = "FileName";
    public const string DefaultPath = "src/file.cs";

    public static File Create(Snippet? id = default, Snippet? name = default, Snippet? path = default)
    {
        return new File
        {
            Id = id ?? Snippet.From(DefaultId),
            Name = name ?? Snippet.From(DefaultName),
            Path = path ?? Snippet.From(DefaultPath),
        };
    }
}