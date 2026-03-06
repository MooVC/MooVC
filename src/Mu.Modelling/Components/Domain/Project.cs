namespace Mu.Modelling.Components.Domain;

using System.Collections.Immutable;
using Graphify;
using MooVC;
using MooVC.Modelling;
using MooVC.Syntax.Attributes.Project;
using MooVC.Syntax.Concepts;
using MooVC.Syntax.CSharp;
using MooVC.Syntax.Elements;
using Builder = MooVC.Syntax.Builder;
using Template = MooVC.Syntax.Concepts.Project;

internal sealed class Project
    : IVisitor<Model.Graph.Areas.Area, File>,
      IVisitor<Model.Graph.Areas.Area.Units.Unit, File>
{
    public IAsyncEnumerable<File> Observe(Model.Graph.Areas.Area area, CancellationToken cancellationToken)
    {
        return Create(area.Value.Description, kernel: string.Empty, area.ProjectName, area.Projects);
    }

    public IAsyncEnumerable<File> Observe(Model.Graph.Areas.Area.Units.Unit unit, CancellationToken cancellationToken)
    {
        string kernel = string.Empty;

        if (unit.Area.Components.Length > 0)
        {
            kernel = unit.KernelName;
        }

        return Create(unit.Value.Description, kernel, unit.ProjectName, unit.Projects);
    }

    private static async IAsyncEnumerable<File> Create(Description description, string kernel, string project, ImmutableArray<Qualifier> projects)
    {
        string content = Builder
            .New<Template>()
            .ForkOn(
                _ => description.IsUndescribed,
                @true: _ => _,
                @false: project => project.WithPropertyGroups(group => group
                    .WithProperty(nameof(Description), description)))
            .WithItemGroups(group => group
                .WithPackage(nameof(Mu))
                .WithPackage(nameof(Muify), muify => muify
                    .WithMetadata("PrivateAssets", "all")
                    .WithMetadata("IncludeAssets", "runtime; build; native; contentfiles; analyzers; buildtransitive")))
            .ForkOn(
                _ => string.IsNullOrEmpty(kernel),
                @true: _ => _,
                @false: kernel => kernel.WithItemGroups(group => group
                    .WithProject($"{Folders.Source}/{kernel}/{kernel}.{Extensions.Project}")))
            .ForkOn(
                _ => projects.IsDefaultOrEmpty,
                @true: _ => _,
                @false: project => project
                    .WithItemGroups(group => group
                        .Enumerate(project => group.WithProject($"{Folders.Source}/{project}/{project}.{Extensions.Project}"), projects)))
            .ToString();

        yield return new File(content, Extensions.Project, project, $"{Folders.Source}/{project}/");
    }
}