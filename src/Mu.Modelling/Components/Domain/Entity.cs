namespace Mu.Modelling.Components.Domain;

using System.Collections.Immutable;
using System.ComponentModel;
using Graphify;
using MooVC;
using MooVC.Modelling;
using MooVC.Syntax.Attributes.Project;
using MooVC.Syntax.CSharp;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;
using Mu.Modelling.Syntax.CSharp.Concepts;
using Muify.Domain;
using Attribute = Mu.Modelling.Attribute;
using Builder = MooVC.Syntax.Builder;

internal sealed class Entity
    : IVisitor<Model.Graph.Areas.Area.Components.Component, File>,
      IVisitor<Model.Graph.Areas.Area.Units.Unit.Components.Component, File>
{
    public IAsyncEnumerable<File> Observe(Model.Graph.Areas.Area.Components.Component component, CancellationToken cancellationToken)
    {
        return Create(
            component.Value.Description,
            component.Value.Identifier,
            component.Value.Name,
            component.Namespace,
            component.ProjectName,
            component.Value.Attributes,
            component.References,
            component.Root.Options);
    }

    public IAsyncEnumerable<File> Observe(Model.Graph.Areas.Area.Units.Unit.Components.Component component, CancellationToken cancellationToken)
    {
        return Create(
            component.Value.Description,
            component.Value.Identifier,
            component.Value.Name,
            component.Namespace,
            component.ProjectName,
            component.Value.Attributes,
            component.References,
            component.Root.Options);
    }

    private static async IAsyncEnumerable<File> Create(
        Description description,
        Attribute identifier,
        Name name,
        Qualifier @namespace,
        string project,
        ImmutableArray<Attribute> properties,
        ImmutableArray<Directive> references,
        Options options)
    {
        if (identifier.IsUndefined)
        {
            yield break;
        }

        var content = Builder
            .New<Definition>()
            .From(@namespace)
            .For<Class>(@class => @class
                .ForkOn(
                    _ => description.IsUndescribed,
                    @true: _ => _,
                    @false: record => record
                        .AttributedWith(description => description
                            .Named(typeof(DescriptionAttribute))
                            .WithArguments((Name: nameof(Description), Value: description))))
                .Named(name)
                .WithProperties(properties)
                .WithProperties(identifier => identifier
                    .AttributedWith(attribute => attribute.Named(typeof(IdentityAttribute)))
                    .Named(identifier.Name)
                    .OfType(identifier.Type)))
            .Referencing([.. references])
            .ToSnippet(options);

        yield return new File(content, Extensions.Code, name, $"{Folders.Source}/{project}/");
    }
}