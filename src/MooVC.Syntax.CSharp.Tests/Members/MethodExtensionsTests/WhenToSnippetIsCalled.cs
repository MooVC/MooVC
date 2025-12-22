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
        Snippet snippet = methods.ToSnippet(Snippet.Options.Default);

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
        Method staticMethod = MethodTestsData.Create(name: new Declaration { Name = "Beta" }, scope: Scope.Public, result: new Result { Type = typeof(int) }, body: Snippet.From("return 1;"));
        staticMethod.Extensibility = Extensibility.Static;

        Method publicVirtual = MethodTestsData.Create(name: new Declaration { Name = "Alpha" }, scope: Scope.Public, result: new Result { Type = typeof(void) }, body: Snippet.From("return;"));
        publicVirtual.Extensibility = Extensibility.Virtual;

        Method protectedVirtual = MethodTestsData.Create(name: new Declaration { Name = "Gamma" }, scope: Scope.Protected, body: Snippet.From("return 3;"));
        protectedVirtual.Extensibility = Extensibility.Virtual;

        ImmutableArray<Method> methods =
        [
            publicVirtual,
            protectedVirtual,
            staticMethod,
        ];

        const string expected = """
            public static int Beta(int value)
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
        Snippet snippet = methods.ToSnippet(options);

        // Assert
        snippet.ToString().ShouldBe(expected);
    }
}
