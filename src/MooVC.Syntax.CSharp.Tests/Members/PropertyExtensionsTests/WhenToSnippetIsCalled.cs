namespace MooVC.Syntax.CSharp.Members.PropertyExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members.PropertyTests;
using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Property> properties = isDefault
            ? default
            : [];

        // Act
        var snippet = properties.ToSnippet(Property.Options.Default);

        // Assert
        snippet.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Property> properties = [PropertyTestsData.Create()];
        Property.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = properties.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenValuesThenTheyAreOrderedByStaticScopeExtensibilityAndName()
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
                get
                {
                    value;
                }
                init;
            }

            public virtual Version Alpha
            {
                get
                {
                    value;
                }
                init;
            }

            protected virtual string Gamma
            {
                get
                {
                    value;
                }
                init;
            }
            """;

        Property.Options options = Property.Options.Default
            .WithSnippets(snippets => snippets
                .WithBlock(block => block
                    .WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces)));

        // Act
        var snippet = properties.ToSnippet(options);

        // Assert
        snippet.ToString().ShouldBe(expected);
    }
}