namespace MooVC.Syntax.CSharp.Syntax
{
    internal static partial class BoolExtensions
    {
        public static string Static(this bool value)
        {
            return value
                ? "static"
                : string.Empty;
        }
    }
}