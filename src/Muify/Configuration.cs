namespace Muify
{
    using MooVC.Syntax.CSharp.Concepts;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.Elements;
    using static MooVC.Syntax.CSharp.Elements.Symbol;
    using Options = MooVC.Syntax.CSharp.Concepts.Options;

    internal static class Configuration
    {
        public static Options Options { get; } = new Options()
            .WithNamespace(Qualifier.Options.Block)
            .WithTypes(types => types.WithQualification(Qualification.Global));
    }
}