namespace MooVC.Syntax.Project
{
    /// <summary>
    /// Provides property-group helper extensions.
    /// </summary>
    public static partial class PropertyGroupExtensions
    {
        /// <summary>
        /// Adds a property entry to the target property group.
        /// </summary>
        /// <param name="group">The property group to update.</param>
        /// <param name="name">The property name.</param>
        /// <param name="value">The property value.</param>
        /// <returns>The updated property group.</returns>
        public static PropertyGroup WithProperty(this PropertyGroup group, Name name, Snippet value)
        {
            return group.WithProperties(property => property
                .Named(name)
                .WithValue(value));
        }
    }
}