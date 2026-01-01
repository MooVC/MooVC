namespace MooVC.Syntax.Attributes.Resource.DataTests;

using MooVC.Syntax.Elements;

internal static class DataTestsData
{
    public const string DefaultComment = "Sample comment";
    public const string DefaultMimeType = "text/plain";
    public const string DefaultName = "Greeting";
    public const string DefaultType = "System.String";
    public const string DefaultValue = "Hello";
    public const string DefaultXmlSpace = "preserve";

    public static Data Create(
        Snippet? comment = default,
        Snippet? mimeType = default,
        Snippet? name = default,
        Snippet? type = default,
        Snippet? value = default,
        Snippet? xmlSpace = default)
    {
        return new Data
        {
            Comment = comment ?? Snippet.From(DefaultComment),
            MimeType = mimeType ?? Snippet.From(DefaultMimeType),
            Name = name ?? Snippet.From(DefaultName),
            Type = type ?? Snippet.From(DefaultType),
            Value = value ?? Snippet.From(DefaultValue),
            XmlSpace = xmlSpace ?? Snippet.From(DefaultXmlSpace),
        };
    }
}