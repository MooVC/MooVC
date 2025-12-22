namespace MooVC.Syntax.CSharp.Members.PropertyExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Members.PropertyTests;

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
        Snippet snippet = properties.ToSnippet(Snippet.Options.Default);

        // Assert
        snippet.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Property> properties = [PropertyTestsData.Create()];
        Snippet.Options? options = default;

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
        staticProperty.Extensibility = Extensibility.Static;

        Property publicVirtual = PropertyTestsData.Create(name: "Alpha", scope: Scope.Public, type: typeof(void));
        publicVirtual.Extensibility = Extensibility.Virtual;

        Property protectedVirtual = PropertyTestsData.Create(name: "Gamma", scope: Scope.Protected, type: typeof(string));
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
            }

            public virtual void Alpha
            {
                get
                {
                    value;
                }
            }

            protected virtual string Gamma
            {
                get
                {
                    value;
                }
            }
            """;

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        // Act
        Snippet snippet = properties.ToSnippet(options);

        // Assert
        snippet.ToString().ShouldBe(expected);
    }
}
