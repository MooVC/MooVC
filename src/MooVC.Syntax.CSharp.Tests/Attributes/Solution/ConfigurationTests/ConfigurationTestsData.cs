namespace MooVC.Syntax.CSharp.Attributes.Solution.ConfigurationTests;

using MooVC.Syntax.CSharp;

internal static class ConfigurationTestsData
{
    public const string DefaultName = "Debug";
    public const string DefaultPlatform = "AnyCPU";

    public static Configuration Create(Snippet? name = default, Snippet? platform = default)
    {
        return new Configuration
        {
            Name = name ?? Snippet.From(DefaultName),
            Platform = platform ?? Snippet.From(DefaultPlatform),
        };
    }
}