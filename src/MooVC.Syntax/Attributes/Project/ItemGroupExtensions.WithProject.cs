namespace MooVC.Syntax.Attributes.Project
{
    using MooVC.Syntax.Elements;

    public static partial class ItemGroupExtensions
    {
        public static ItemGroup WithProject(this ItemGroup group, Snippet path)
        {
            return group.WithItems(project => project
                .Named("ProjectReference")
                .WithInclude(path));
        }
    }
}