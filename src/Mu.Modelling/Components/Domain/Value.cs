namespace Mu.Modelling.Components.Domain;

using System.Runtime.CompilerServices;
using Graphify;
using MooVC.Modelling;
using MooVC.Syntax.Attributes.Project;
using MooVC.Syntax.CSharp;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using Mu.Modelling.Syntax.CSharp.Concepts;
using Builder = MooVC.Syntax.Builder;

internal sealed class Value
    : IVisitor<Model.Graph.Areas.Area.Units.Unit.Components.Component, File>
{
    public async IAsyncEnumerable<File> Observe(
        Model.Graph.Areas.Area.Units.Unit.Components.Component component,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (!component.Value.Identifier.IsUndefined)
        {
            yield break;
        }

        var content = Builder
            .New<Definition>()
            .From(component.Namespace)
            .For<Record>(record => record
                .Named(component.Value.Name)
                .WithProperties(component.Value.Attributes))
            .Referencing(component.References)
            .ToSnippet(component.Root.Options);

        yield return new File(content, Extensions.Code, component.Value.Name, $"src/{component.ProjectName}/");
    }
}