namespace MooVC.Syntax.Elements.PathTests;

using SystemPath = System.IO.Path;

internal static class PathTestsData
{
    public const string DefaultDirectoryName = "src";
    public const string DefaultFileName = "Resources.resx";
    public const string DefaultFileNameWithoutExtension = "Resources";
    public const string DefaultExtension = ".resx";
    public const string ChangedExtension = ".Designer.cs";

    public static readonly string DefaultPath = SystemPath.Combine(DefaultDirectoryName, DefaultFileName);
    public static readonly string DefaultAlternativePath = SystemPath.Combine("assets", "Other.resx");
    public static readonly string DefaultChangedExtensionPath = SystemPath.ChangeExtension(DefaultPath, ChangedExtension);
}