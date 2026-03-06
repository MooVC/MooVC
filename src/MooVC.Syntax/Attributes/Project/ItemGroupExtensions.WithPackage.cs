namespace MooVC.Syntax.Attributes.Project
{
    using System;
    using MooVC.Syntax.Elements;

    public static partial class ItemGroupExtensions
    {
        public static ItemGroup WithPackage(this ItemGroup group, Qualifier name)
        {
            return group.WithPackage(name, default);
        }

        public static ItemGroup WithPackage(this ItemGroup group, Qualifier name, Func<Item, Item> builder)
        {
            return group.WithItems(package => package
                .Named("PackageReference")
                .WithInclude(name)
                .Apply(builder));
        }
    }
}