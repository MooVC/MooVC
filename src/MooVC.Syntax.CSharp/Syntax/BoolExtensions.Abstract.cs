namespace MooVC.Syntax.CSharp.Syntax
{
    internal static partial class BoolExtensions
    {
        public static string Abstract(this bool value)
        {
            return value
                ? "abstract"
                : string.Empty;
        }
    }
}