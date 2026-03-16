namespace MooVC.Syntax.CSharp.Elements.Chaining
{
    using System.Collections.Immutable;
    using MooVC.Syntax.Elements;

    public sealed class ArgumentChainingChain
        : Snippet.IChain
    {
        public ImmutableArray<string> Chain(string line, int maxLength)
        {
            return ParenthesesChaining.Chain(line, maxLength);
        }
    }
}
