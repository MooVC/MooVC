namespace Mu.Modelling.Components.Feature;

using System.Runtime.CompilerServices;
using Graphify;
using MooVC;
using MooVC.Modelling;
using MooVC.Syntax.Attributes.Project;
using MooVC.Syntax.Concepts;
using MooVC.Syntax.CSharp;
using Builder = MooVC.Syntax.Builder;
using Template = MooVC.Syntax.Concepts.Project;

internal sealed class Project
    : IVisitor<Model.Graph.Areas.Area.Units.Unit.Features.Feature, File>
{
    public async IAsyncEnumerable<File> Observe(
        Model.Graph.Areas.Area.Units.Unit.Features.Feature feature,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        string content = Builder
            .New<Template>()
            .ForkOn(
                _ => feature.Value.Description.IsUndescribed,
                @true: _ => _,
                @false: project => project.WithPropertyGroups(group => group
                    .WithProperty(nameof(feature.Value.Description), feature.Value.Description)))
            .WithItemGroups(group => group
                .WithProject($"{Folders.Source}/{feature.DomainName}/{feature.DomainName}.{Extensions.Project}"))
            .ToString();

        yield return new File(content, Extensions.Project, feature.ProjectName, $"{Folders.Source}/{feature.ProjectName}/");
    }
}