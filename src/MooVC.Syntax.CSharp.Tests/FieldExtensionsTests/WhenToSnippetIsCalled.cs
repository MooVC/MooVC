namespace MooVC.Syntax.CSharp.FieldExtensionsTests;

using System;
using System.Collections.Immutable;
using Options = MooVC.Syntax.CSharp.Type.Options;

public sealed class WhenToSnippetIsCalled
{
    private const string FirstFieldName = "Alpha";
    private const string SecondFieldName = "Beta";
    private const string ThirdFieldName = "Gamma";

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Field> fields = isDefault
            ? default
            : [];

        // Act
        var snippet = fields.ToSnippet(Options.Default);

        // Assert
        _ = await Assert.That(snippet).IsEqualTo(Snippet.Empty);
    }

    [Test]
    public async Task GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Field> fields = [Create(name: FirstFieldName)];
        Options? options = default;

        // Act
        Func<Snippet> act = () => _ = fields.ToSnippet(options!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenValuesThenTheyAreOrderedByStaticReadonlyScopeAndName()
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
        var snippet = fields.ToSnippet(Options.Default);

        // Assert
        _ = await Assert.That(snippet.ToString()).IsEqualTo(expected);
    }

    private static Field Create(string name, bool isStatic = false, bool isReadOnly = true, Scope? scope = default)
    {
        return new Field
        {
            IsReadOnly = isReadOnly,
            IsStatic = isStatic,
            Name = new(name),
            Scope = scope ?? Scope.Public,
            Type = typeof(string),
        };
    }
}