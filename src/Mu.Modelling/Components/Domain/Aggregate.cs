namespace Mu.Modelling.Components.Domain;

extern alias Framework;

using System.Runtime.CompilerServices;
using Graphify;
using MooVC.Modelling;
using MooVC.Syntax.Attributes.Project;
using MooVC.Syntax.CSharp;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using Mu.Modelling.Syntax.CSharp.Concepts;
using Base = Framework::Mu.Modelling.State.Aggregate;
using Builder = MooVC.Syntax.Builder;

internal sealed class Aggregate
    : IVisitor<Model.Graph.Areas.Area.Units.Unit, File>
{
    public async IAsyncEnumerable<File> Observe(Model.Graph.Areas.Area.Units.Unit unit, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var content = Builder
            .New<Definition>()
            .From(unit.Namespace)
            .For<Record>(record => record
                .Named(unit.Value.Name)
                .DerivesFrom(typeof(Base))
                .WithProperties(unit.Value.Attributes))
            .Referencing(unit.References)
            .ToSnippet(unit.Root.Options);

        yield return new File(content, Extensions.Code, unit.Value.Name, $"src/{unit.ProjectName}/");
    }
}