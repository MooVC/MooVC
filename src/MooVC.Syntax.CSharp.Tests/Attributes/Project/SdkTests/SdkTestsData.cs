namespace MooVC.Syntax.CSharp.Attributes.Project.SdkTests;

using MooVC.Syntax.CSharp.Elements;

internal static class SdkTestsData
{
    public const string DefaultMinimumVersion = "1.0.0";
    public const string DefaultVersion = "9.9.9";
    public static readonly Qualifier DefaultName = "MooVC.Sdk";

    public static Sdk Create(Snippet? minimumVersion = default, Qualifier? name = default, Snippet? version = default)
    {
        return new Sdk
        {
            MinimumVersion = minimumVersion ?? Snippet.From(DefaultMinimumVersion),
            Name = name ?? DefaultName,
            Version = version ?? Snippet.From(DefaultVersion),
        };
    }
}