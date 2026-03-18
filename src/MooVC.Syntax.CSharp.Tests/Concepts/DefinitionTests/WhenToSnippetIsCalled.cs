namespace MooVC.Syntax.CSharp.Concepts.DefinitionTests;

using MooVC.Syntax;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;
using static MooVC.Syntax.CSharp.Elements.Symbol;
using Attribute = System.Attribute;
using Options = MooVC.Syntax.CSharp.Concepts.Options;

public sealed class WhenToSnippetIsCalled
{
    private static readonly Options _options = new Options()
        .WithNamespace(Qualifier.Options.Block)
        .WithTypes(types => types.WithQualification(Qualification.Global));

    [Test]
    public async Task GivenInstructionsWhenAttributeThenAttributeIsCreated()
    {
        // Arrange
        const string expected = """
            namespace Muify.Domain
            {
                [global::System.AttributeUsageAttribute(global::System.AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
                internal sealed partial class IdentityAttribute
                    : global::System.Attribute
                {
                }
            }
            """;

        Definition content = Builder
            .New<Definition>()
            .From("Muify.Domain")
            .For<Class>(@class => @class
                .AttributedWith(attribute => attribute
                    .Named(typeof(AttributeUsageAttribute))
                    .WithArguments(
                        (Name: string.Empty, Value: "global::System.AttributeTargets.Property"),
                        (Name: nameof(AttributeUsageAttribute.AllowMultiple), Value: "false"),
                        (Name: nameof(AttributeUsageAttribute.Inherited), Value: "false")))
                .DerivesFrom(typeof(Attribute))
                .Named("IdentityAttribute")
                .WithScope(Scope.Internal));

        // Act
        var actual = content.ToSnippet(_options);

        // Assert
        await Assert.That(actual.ToString()).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenInstructionsWhenAttributeWithPropertiesThenAttributeIsCreated()
    {
        // Arrange
        const string expected = """
            namespace Muify.Domain
            {
                [global::System.AttributeUsageAttribute(global::System.AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
                internal sealed partial class RaisesAttribute
                    : global::System.Attribute
                {
                    public string Name { get; set; }
                }
            }
            """;

        Definition content = Builder
            .New<Definition>()
            .From("Muify.Domain")
            .For<Class>(@class => @class
                .AttributedWith(attribute => attribute
                    .Named(typeof(AttributeUsageAttribute))
                    .WithArguments(
                        (Name: string.Empty, Value: "global::System.AttributeTargets.Property"),
                        (Name: nameof(AttributeUsageAttribute.AllowMultiple), Value: "false"),
                        (Name: nameof(AttributeUsageAttribute.Inherited), Value: "false")))
                .DerivesFrom(typeof(Attribute))
                .Named("RaisesAttribute")
                .WithProperties(name => name
                    .Named("Name")
                    .OfType(typeof(string))
                    .WithBehaviours(behaviors => behaviors
                        .WithSet(set => set.WithMode(Property.Mode.Set))))
                .WithScope(Scope.Internal));

        // Act
        var actual = content.ToSnippet(_options);

        // Assert
        await Assert.That(actual.ToString()).IsEqualTo(expected);
    }
}