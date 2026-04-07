namespace MooVC.Syntax.CSharp.PropertyExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.PropertyTests;

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
        _ = await Assert.That(snippet).IsEqualTo(Snippet.Empty);
    }

    [Test]
    public async Task GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Property> properties = [PropertyTestsData.Create()];
        Property.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = properties.ToSnippet(options!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenValuesThenTheyAreOrderedByStaticScopeExtensibilityAndName()
    {
        // Arrange
        Property staticProperty = PropertyTestsData.Create(name: "Beta", scope: Scopes.Public, type: typeof(int));
        Property publicVirtual = PropertyTestsData.Create(name: "Alpha", scope: Scopes.Public, type: typeof(Version));
        Property protectedVirtual = PropertyTestsData.Create(name: "Gamma", scope: Scopes.Protected, type: typeof(string));

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
        _ = await Assert.That(snippet.ToString()).IsEqualTo(expected);
    }
}