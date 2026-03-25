namespace MooVC.Syntax.Project
{
    /// <summary>
    /// Provides item-group helper extensions.
    /// </summary>
    public static partial class ItemGroupExtensions
    {
        /// <summary>
        /// Adds a project reference item to an item group.
        /// </summary>
        /// <param name="group">The item group to update.</param>
        /// <param name="path">The project path to include.</param>
        /// <returns>The updated item group.</returns>
        public static ItemGroup WithProject(this ItemGroup group, Snippet path)
        {
            return group.WithItems(project => project
                .Named("ProjectReference")
                .WithInclude(path));
        }
    }
}