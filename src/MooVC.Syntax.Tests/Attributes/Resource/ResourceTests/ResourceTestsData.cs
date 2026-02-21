namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

using MooVC.Syntax.Elements;

internal static class ResourceTestsData
{
    public const string DefaultCustomToolNamespace = "MooVC.Resources";
    public const string DefaultDesignerPath = "Resources.Designer.cs";
    public const string DefaultLocationPath = "Resources.resx";

    public static Resource Create(
        Snippet? customToolNamespace = default,
        Path? designer = default,
        Path? location = default,
        Resource.Scope visibility = Resource.Scope.Internal)
    {
        return new Resource
        {
            CustomToolNamespace = customToolNamespace ?? Snippet.From(DefaultCustomToolNamespace),
            Designer = designer ?? new Path(DefaultDesignerPath),
            Location = location ?? new Path(DefaultLocationPath),
            Visibility = visibility,
        };
    }
}