namespace MooVC.Syntax.CSharp.MethodExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.MethodTests;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Method> methods = isDefault
            ? default
            : [];

        // Act
        var snippet = methods.ToSnippet(Method.Options.Default);

        // Assert
        _ = await Assert.That(snippet).IsEqualTo(Snippet.Empty);
    }

    [Test]
    public async Task GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Method> methods = [MethodTestsData.Create()];
        Method.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = methods.ToSnippet(options!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenValuesThenTheyAreOrderedByStaticScopeExtensibilityAndName()
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

        // Act
        var snippet = methods.ToSnippet(Method.Options.Default);

        // Assert
        _ = await Assert.That(snippet.ToString()).IsEqualTo(expected);
    }
}