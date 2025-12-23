namespace MooVC.Syntax.CSharp.Members.FieldExtensionsTests;

using System;
using System.Collections.Immutable;

public sealed class WhenToSnippetIsCalled
{
    private const string FirstFieldName = "Alpha";
    private const string SecondFieldName = "Beta";
    private const string ThirdFieldName = "Gamma";

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Field> fields = isDefault
            ? default
            : [];

        // Act
        var snippet = fields.ToSnippet(Snippet.Options.Default);

        // Assert
        snippet.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Field> fields = [Create(name: FirstFieldName)];
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = fields.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenValuesThenTheyAreOrderedByStaticReadonlyScopeAndName()
    {
        // Arrange
        Field staticReadonly = Create(name: ThirdFieldName, isStatic: true, isReadOnly: true);
        Field staticMutable = Create(name: SecondFieldName, isStatic: true, isReadOnly: false, scope: Scope.Private);
        Field instanceReadonly = Create(name: FirstFieldName, isStatic: false, isReadOnly: true, scope: Scope.Public);

        ImmutableArray<Field> fields =
        [
            instanceReadonly,
            staticMutable,
            staticReadonly,
        ];

        const string expected = """
            public static readonly string Gamma;
            private static string Beta;
            public readonly string Alpha;
            """;

        // Act
        var snippet = fields.ToSnippet(Snippet.Options.Default);

        // Assert
        snippet.ToString().ShouldBe(expected);
    }

    private static Field Create(string name, bool isStatic = false, bool isReadOnly = true, Scope? scope = default)
    {
        return new Field
        {
            IsReadOnly = isReadOnly,
            IsStatic = isStatic,
            Name = new Identifier(name),
            Scope = scope ?? Scope.Public,
            Type = typeof(string),
        };
    }
}