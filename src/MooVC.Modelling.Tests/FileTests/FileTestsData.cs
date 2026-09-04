namespace MooVC.Modelling.FileTests;

internal static class FileTestsData
{
    public const string DefaultContent = "content";
    public const string DefaultExtension = "txt";
    public const string DefaultName = "example";
    public const string DefaultPath = "Models";
    public const string OtherContent = "other content";

    public static File Create(
        string? content = default,
        string? extension = default,
        string? name = default,
        string? path = default)
    {
        return new File(
            content ?? DefaultContent,
            extension ?? DefaultExtension,
            name ?? DefaultName,
            path ?? DefaultPath);
    }
}