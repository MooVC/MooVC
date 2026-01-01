namespace MooVC.Syntax.CSharp.Syntax
{
    internal static partial class BoolExtensions
    {
        public static string Partial(this bool value)
        {
            return value
                ? "partial"
                : string.Empty;
        }
    }
}