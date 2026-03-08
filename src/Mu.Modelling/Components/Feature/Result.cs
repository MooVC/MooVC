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

internal sealed class Result
    : IVisitor<Model.Graph.Areas.Area.Units.Unit.Features.Feature, File>
{
    public async IAsyncEnumerable<File> Observe(
        Model.Graph.Areas.Area.Units.Unit.Features.Feature feature,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var content = Builder
            .New<Definition>()
            .From(feature.Namespace)
            .For<Record>(record => record
                .Containing(Type
                    .New<Record>()
                    .Named(nameof(Result))
                    .WithParameters(feature.Value.Results))
                .Named(feature.Value.Name))
            .Referencing([.. feature.References])
            .ToSnippet(feature.Root.Options);

        yield return new File(content, Extensions.Code, $"{feature.Value.Name}.{nameof(Result)}", $"{Folders.Source}/{feature.ProjectName}/");
    }
}