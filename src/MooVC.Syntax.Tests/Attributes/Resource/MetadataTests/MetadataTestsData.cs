namespace MooVC.Syntax.Attributes.Resource.MetadataTests;

using MooVC.Syntax.Elements;

internal static class MetadataTestsData
{
    public const string DefaultMimeType = "text/plain";
    public const string DefaultName = "MetadataKey";
    public const string DefaultType = "System.String";
    public const string DefaultValue = "MetadataValue";

    public static Metadata Create(Snippet? mimeType = default, Snippet? name = default, Snippet? type = default, Snippet? value = default)
    {
        return new Metadata
        {
            MimeType = mimeType ?? Snippet.From(DefaultMimeType),
            Name = name ?? Snippet.From(DefaultName),
            Type = type ?? Snippet.From(DefaultType),
            Value = value ?? Snippet.From(DefaultValue),
        };
    }
}