namespace MooVC.Syntax
{
    using MooVC.Syntax.Concepts;

    /// <summary>
    /// Represents a syntax helper builder.
    /// </summary>
    public static class Builder
    {
        /// <summary>
        /// Performs the new t operation for the syntax helper.
        /// </summary>
        /// <returns>The t.</returns>
        public static T New<T>()
            where T : Construct, new()
        {
            return new T();
        }
    }
}