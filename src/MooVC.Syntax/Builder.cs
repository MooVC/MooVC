namespace MooVC.Syntax
{
    using MooVC.Syntax.Concepts;

    /// <summary>
    /// Represents a syntax helper builder.
    /// </summary>
    public static class Builder
    {
        /// <summary>
        /// Performs the New T operation for the syntax helper.
        /// </summary>
        public static T New<T>()
            where T : Construct, new()
        {
            return new T();
        }
    }
}