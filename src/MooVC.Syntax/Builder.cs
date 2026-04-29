namespace MooVC.Syntax
{
    /// <summary>
    /// Provides factory helpers for syntax constructs.
    /// </summary>
    /// <remarks>
    /// The builder centralizes object creation so fluent configuration can begin from a single entry point.
    /// </remarks>
    public static class Builder
    {
        /// <summary>
        /// Creates a new instance of the specified construct type.
        /// </summary>
        /// <typeparam name="T">The syntax construct type to create.</typeparam>
        /// <returns>A new instance of <typeparamref name="T"/>.</returns>
        public static T New<T>()
            where T : Construct, new()
        {
            return new T();
        }
    }
}