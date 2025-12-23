namespace MooVC.Syntax.CSharp.Members.MethodExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Members.MethodTests;

public sealed class WhenToSnippetIsCalled
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Method> methods = isDefault
            ? default
            : [];

        // Act
        var snippet = methods.ToSnippet(Snippet.Options.Default);

        // Assert
        snippet.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Method> methods = [MethodTestsData.Create()];
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = methods.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenValuesThenTheyAreOrderedByStaticScopeExtensibilityAndName()
    {
        // Arrange
        Method staticMethod = MethodTestsData.Create(
            name: new Declaration { Name = "Beta" },
            scope: Scope.Public,
            result: new Result { Type = typeof(int) }.AsTask(),
            body: Snippet.From("return 1;"));

        Method publicVirtual = MethodTestsData.Create(
            name: new Declaration { Name = "Alpha" },
            scope: Scope.Public,
            result: Result.Void,
            body: Snippet.From("return;"));

        Method protectedVirtual = MethodTestsData.Create(
            name: new Declaration { Name = "Gamma" },
            scope: Scope.Protected,
            body: Snippet.From("return 3;"));

        staticMethod.Extensibility = Extensibility.Static;
        publicVirtual.Extensibility = Extensibility.Virtual;
        protectedVirtual.Extensibility = Extensibility.Virtual;

        ImmutableArray<Method> methods =
        [
            publicVirtual,
            protectedVirtual,
            staticMethod,
        ];

        const string expected = """
            public static async Task<int> Beta(int value)
            {
                return 1;
            }

            public virtual void Alpha(int value)
            {
                return;
            }

            protected virtual string Gamma(int value)
            {
                return 3;
            }
            """;

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        // Act
        var snippet = methods.ToSnippet(options);

        // Assert
        snippet.ToString().ShouldBe(expected);
    }
}