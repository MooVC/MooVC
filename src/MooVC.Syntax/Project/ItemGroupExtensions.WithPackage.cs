namespace MooVC.Syntax.Project
{
    using System;

    /// <summary>
    /// Provides item-group helper extensions.
    /// </summary>
    public static partial class ItemGroupExtensions
    {
        /// <summary>
        /// Adds a package reference item to an item group.
        /// </summary>
        /// <param name="group">The item group to update.</param>
        /// <param name="name">The package identifier.</param>
        /// <returns>The updated item group.</returns>
        public static ItemGroup WithPackage(this ItemGroup group, Qualifier name)
        {
            return group.WithPackage(name, default);
        }

        /// <summary>
        /// Adds and customizes a package reference item in an item group.
        /// </summary>
        /// <param name="group">The item group to update.</param>
        /// <param name="name">The package identifier.</param>
        /// <param name="builder">A callback used to customize the package item.</param>
        /// <returns>The updated item group.</returns>
        public static ItemGroup WithPackage(this ItemGroup group, Qualifier name, Func<Item, Item> builder)
        {
            return group.WithItems(package => package
                .Named("PackageReference")
                .WithInclude(name)
                .Apply(builder));
        }
    }
}