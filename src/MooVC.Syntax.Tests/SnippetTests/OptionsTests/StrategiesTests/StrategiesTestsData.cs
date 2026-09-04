namespace MooVC.Syntax.SnippetTests.OptionsTests.StrategiesTests;

using System.Collections.Immutable;

internal static class StrategiesTestsData
{
    public static readonly ImmutableArray<Snippet.Options.IChain> Alternate = [new AlternateChain()];

    public static readonly ImmutableArray<Snippet.Options.IChain> Empty = ImmutableArray<Snippet.Options.IChain>.Empty;

    public static readonly ImmutableArray<Snippet.Options.IChain> Primary = [new PrimaryChain()];

    private sealed class AlternateChain : Snippet.Options.IChain
    {
        public ImmutableArray<string> Chain(string line, Snippet.Options options)
        {
            return [$"alternate:{line}"];
        }
    }

    private sealed class PrimaryChain : Snippet.Options.IChain
    {
        public ImmutableArray<string> Chain(string line, Snippet.Options options)
        {
            return [$"primary:{line}"];
        }
    }
}