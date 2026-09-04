namespace MooVC.Syntax.Resource.ItemTests;

internal static class ItemTestsData
{
    public const string DefaultCustomToolNamespace = "MooVC.Resources";
    public const string DefaultDesignerPath = "Resources.Designer.cs";
    public const string DefaultLocationPath = "Resources.resx";

    public static Item Create(
        Snippet? customToolNamespace = default,
        Path? designer = default,
        Path? location = default,
        Item.Scope visibility = Item.Scope.Internal)
    {
        return new Item
        {
            CustomToolNamespace = customToolNamespace ?? Snippet.From(DefaultCustomToolNamespace),
            Designer = designer ?? new Path(DefaultDesignerPath),
            Location = location ?? new Path(DefaultLocationPath),
            Visibility = visibility,
        };
    }
}