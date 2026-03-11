namespace Mu.Modelling;

using Ardalis.GuardClauses;
using MooVC.Syntax.Validation;
using static Mu.Modelling.Options;
using SyntaxOptions = MooVC.Syntax.CSharp.Concepts.Options;

public sealed partial record Options(GithubOptions Github, SyntaxOptions Syntax)
{
    public static readonly Options Default = new();

    public Options()
        : this(GithubOptions.Default, SyntaxOptions.Default)
    {
    }

    public static implicit operator GithubOptions(Options options)
    {
        Guard.Against.Conversion<Options, GithubOptions>(options);

        return options.Github;
    }

    public static implicit operator SyntaxOptions(Options options)
    {
        Guard.Against.Conversion<Options, SyntaxOptions>(options);

        return options.Syntax;
    }
}