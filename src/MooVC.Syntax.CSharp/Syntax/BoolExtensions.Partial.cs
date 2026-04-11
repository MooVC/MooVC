namespace MooVC.Syntax.CSharp.Syntax
{
    /// <summary>
    /// Provides fluent helpers for emitting C# boolean-related keywords.
    /// </summary>
    internal static partial class BoolExtensions
    {
        /// <summary>
        /// Performs the partial operation for the C# keyword syntax.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The string.</returns>
        public static string Partial(this bool value)
        {
            return value
                ? "partial"
                : string.Empty;
        }
    }
}