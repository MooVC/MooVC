namespace Mu.Modelling.Components.Domain;

using System.Runtime.CompilerServices;
using Graphify;
using MooVC.Modelling;
using MooVC.Syntax.Attributes.Project;
using MooVC.Syntax.Concepts;
using MooVC.Syntax.CSharp;
using Builder = MooVC.Syntax.Builder;
using Template = MooVC.Syntax.Concepts.Project;

internal sealed class Project
    : IVisitor<Model.Graph.Areas.Area.Units.Unit, File>
{
    public async IAsyncEnumerable<File> Observe(Model.Graph.Areas.Area.Units.Unit unit, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        string content = Builder
            .New<Template>()
            .WithPropertyGroups(group => group.WithProperties())
            .ToString();

        yield return new File(content, Extensions.Project, unit.Value.Name, $"src/{unit.ProjectName}/");
    }
}