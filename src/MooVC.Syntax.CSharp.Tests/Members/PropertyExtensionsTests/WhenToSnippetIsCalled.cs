namespace MooVC.Syntax.CSharp.Members.PropertyExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members.PropertyTests;
using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Property> properties = isDefault
            ? default
            : [];

        // Act
        var snippet = properties.ToSnippet(Property.Options.Default);

        // Assert
        await Assert.That(snippet).IsEqualTo(Snippet.Empty);
    }

    [Test]
    public async Task GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Property> properties = [PropertyTestsData.Create()];
        Property.Options? options = default;

        // Act
        ArgumentNullException exception = await Assert.That(() => _ = properties.ToSnippet(options!)).Throws<ArgumentNullException>();

        // Assert
        await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenValuesThenTheyAreOrderedByStaticScopeExtensibilityAndName()
    {
        // Arrange
        Property staticProperty = PropertyTestsData.Create(name: "Beta", scope: Scope.Public, type: typeof(int));
        Property publicVirtual = PropertyTestsData.Create(name: "Alpha", scope: Scope.Public, type: typeof(Version));
        Property protectedVirtual = PropertyTestsData.Create(name: "Gamma", scope: Scope.Protected, type: typeof(string));

        staticProperty.Extensibility = Extensibility.Static;
        publicVirtual.Extensibility = Extensibility.Virtual;
        protectedVirtual.Extensibility = Extensibility.Virtual;

        ImmutableArray<Property> properties =
        [
            publicVirtual,
            staticProperty,
            protectedVirtual,
        ];

        const string expected = """
            public static int Beta
            {
                get => value;
                init;
            }

            public virtual Version Alpha
            {
                get => value;
                init;
            }

            protected virtual string Gamma
            {
                get => value;
                init;
            }
            """;

        // Act
        var snippet = properties.ToSnippet(Property.Options.Default);

        // Assert
        await Assert.That(snippet.ToString()).IsEqualTo(expected);
    }
}