namespace Mu.Modelling;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;

public static partial class ParameterExtensions
{
    internal static ImmutableArray<Directive> GetReferences(this IEnumerable<Parameter> parameters, Qualifier source)
    {
        return [.. parameters
            .Select(attribute => attribute.Type.Qualifier)
            .Distinct()
            .Where(qualifier => qualifier != source)
            .OrderBy(qualifier => qualifier)
            .Select(qualifier => (Directive)qualifier)];
    }
}