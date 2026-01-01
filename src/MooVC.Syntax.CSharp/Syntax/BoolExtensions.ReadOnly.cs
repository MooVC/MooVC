namespace MooVC.Syntax.CSharp.Syntax
{
    /// <summary>
    /// Represents a c# keyword syntax bool extensions.
    /// </summary>
    internal static partial class BoolExtensions
    {
        /// <summary>
        /// Performs the Read Only operation for the c# keyword syntax.
        /// </summary>
        public static string ReadOnly(this bool value)
        {
            return value
                ? "readonly"
                : string.Empty;
        }
    }
}