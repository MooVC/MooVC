namespace MooVC.Syntax.CSharp
{
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.CSharp.Symbol_Resources;
    using CType = System.Type;

    /// <summary>
    /// Represents the return signature for methods, operators, and delegates.
    /// </summary>
    public partial class Symbol
    {
        /// <summary>
        /// Wraps the Result in a type.
        /// </summary>
        /// <param name="wrapper">The wrapper.</param>
        /// <returns>The result.</returns>
        public Symbol As(CType wrapper)
        {
            _ = Guard.Against.Null(wrapper, message: AsWrapperRequired.Format(this));

            return new Symbol()
                .Named(wrapper)
                .WithArguments(this);
        }
    }
}