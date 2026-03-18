namespace MooVC.Syntax.Project
{
    public static partial class PropertyGroupExtensions
    {
        public static PropertyGroup WithProperty(this PropertyGroup group, Name name, Snippet value)
        {
            return group.WithProperties(property => property
                .Named(name)
                .WithValue(value));
        }
    }
}