namespace MooVC.Syntax.Attributes.Project
{
    using MooVC.Syntax.Elements;

    public static partial class ItemExtensions
    {
        public static Item WithMetadata(this Item item, Name name, Snippet value)
        {
            return item.WithMetadata(metadata => metadata
                .Named(name)
                .WithValue(value));
        }
    }
}