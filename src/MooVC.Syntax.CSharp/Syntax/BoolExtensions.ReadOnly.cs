namespace MooVC.Syntax.CSharp.Syntax
{
    internal static partial class BoolExtensions
    {
        public static string ReadOnly(this bool value)
        {
            return value
                ? "readonly"
                : string.Empty;
        }
    }
}