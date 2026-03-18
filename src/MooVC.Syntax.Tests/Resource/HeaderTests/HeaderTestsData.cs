namespace MooVC.Syntax.Resource.HeaderTests;

internal static class HeaderTestsData
{
    public const string DefaultName = "resmimetype";
    public const string DefaultValue = "text/microsoft-resx";

    public static Header Create(Snippet? name = default, Snippet? value = default)
    {
        return new Header
        {
            Name = name ?? Snippet.From(DefaultName),
            Value = value ?? Snippet.From(DefaultValue),
        };
    }
}