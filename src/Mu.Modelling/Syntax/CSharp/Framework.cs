namespace Mu.Modelling.Syntax.CSharp;

using MooVC.Syntax.CSharp.Elements;

internal static partial class Framework
{
    public static class Attributes
    {
        public static readonly Func<Symbol, Symbol> Identity = symbol => symbol
            .Named("Identity")
            .From("Mu");
    }
}