namespace MooVC.Syntax.CSharp.Syntax
{
    /// <summary>
    /// Represents a c# keyword syntax bool extensions.
    /// </summary>
    internal static partial class BoolExtensions
    {
        /// <summary>
        /// Performs the Partial operation for the c# keyword syntax.
        /// </summary>
        public static string Partial(this bool value)
        {
            return value
                ? "partial"
                : string.Empty;
        }
    }
}