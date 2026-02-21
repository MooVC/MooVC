namespace Muify;

using System.Diagnostics;
using Microsoft.CodeAnalysis.Testing;

[DebuggerDisplay("{Hint,nq}")]
public sealed record Generated(string Content, Type Generator, string Hint)
{
    public void IsExpectedIn(SolutionState state)
    {
        Type generator = Generator;

        state.GeneratedSources.Add((sourceGeneratorType: generator, filename: Hint, content: Content));
    }
}