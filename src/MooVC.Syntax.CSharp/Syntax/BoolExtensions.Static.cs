namespace MooVC.Syntax.CSharp.Syntax
{
    /// <summary>
    /// Represents a c# keyword syntax bool extensions.
    /// </summary>
    internal static partial class BoolExtensions
    {
        /// <summary>
        /// Performs the Static operation for the c# keyword syntax.
        /// </summary>
        public static string Static(this bool value)
        {
            return value
                ? "static"
                : string.Empty;
        }
    }
}