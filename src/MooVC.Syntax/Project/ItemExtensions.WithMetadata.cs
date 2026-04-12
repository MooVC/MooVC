namespace MooVC.Syntax.Project
{
    /// <summary>
    /// Provides item helper extensions.
    /// </summary>
    public static partial class ItemExtensions
    {
        /// <summary>
        /// Adds metadata to an item using the provided name and value.
        /// </summary>
        /// <param name="item">The item to update.</param>
        /// <param name="name">The metadata name.</param>
        /// <param name="value">The metadata value.</param>
        /// <returns>The updated item.</returns>
        public static Item WithMetadata(this Item item, Name name, Snippet value)
        {
            return item.WithMetadata(metadata => metadata
                .Named(name)
                .WithValue(value));
        }
    }
}