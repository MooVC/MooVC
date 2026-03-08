namespace Mu.Modelling.Components.Feature;

extern alias Framework;

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Graphify;
using MooVC;
using MooVC.Modelling;
using MooVC.Syntax.Attributes.Project;
using MooVC.Syntax.CSharp;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using Mu.Modelling.Syntax.CSharp.Concepts;
using Muify.Domain;
using Builder = MooVC.Syntax.Builder;
using Type = System.Type;

internal sealed class Request
    : IVisitor<Model.Graph.Areas.Area.Units.Unit.Features.Feature, File>
{
    public async IAsyncEnumerable<File> Observe(
        Model.Graph.Areas.Area.Units.Unit.Features.Feature feature,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        Type @base = GetBaseType(feature);

        var content = Builder
            .New<Definition>()
            .From(feature.Namespace)
            .For<Record>(record => record
                .ForkOn(
                    _ => feature.Value.Description.IsUndescribed,
                    @true: _ => _,
                    @false: record => record
                        .AttributedWith(description => description
                            .Named(typeof(DescriptionAttribute))
                            .WithArguments((Name: nameof(Description), Value: feature.Value.Description))))
                .ForkOn(
                    _ => feature.Value.Type.IsMutational,
                    @true: record => record
                        .AttributedWith(description => description
                            .Named(typeof(RaisesAttribute))
                            .WithArguments((Name: nameof(Description), Value: feature.Value.Description))),
                    @false: _ => _)
                .DerivesFrom(@base)
                .Named(feature.Value.Name)
                .WithParameters(feature.Value.Parameters))
            .Referencing([.. feature.References])
            .ToSnippet(feature.Root.Options);

        yield return new File(content, Extensions.Code, feature.Value.Name, $"{Folders.Source}/{feature.ProjectName}/");
    }

    private static Type GetBaseType(Model.Graph.Areas.Area.Units.Unit.Features.Feature feature)
    {
        return feature.Value.Type.IsMutational
            ? GetMutationalBaseType(feature)
            : typeof(Framework::Mu.Modelling.Behavior.Query);
    }

    private static Type GetMutationalBaseType(Model.Graph.Areas.Area.Units.Unit.Features.Feature feature)
    {
        return feature.Value.Mutational.Type.IsCreational
            ? typeof(Framework::Mu.Modelling.Behavior.Creational)
            : typeof(Framework::Mu.Modelling.Behavior.Transitional);
    }
}