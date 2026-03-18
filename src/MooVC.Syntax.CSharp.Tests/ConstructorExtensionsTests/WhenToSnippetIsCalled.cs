namespace MooVC.Syntax.CSharp.ConstructorExtensionsTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp;
using MooVC.Syntax.CSharp.ParameterTests;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Constructor> constructors = isDefault
            ? default
            : [];

        Type type = OperatorsTestsData.Create();

        // Act
        var snippet = constructors.ToSnippet(Type.Options.Default, type);

        // Assert
        _ = await Assert.That(snippet).IsEqualTo(Snippet.Empty);
    }

    [Test]
    public async Task GivenNullConstructThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Constructor> constructors = [Create([])];
        OperatorsTestsData.TestType? type = default;

        // Act
        Func<Snippet> act = () => _ = constructors.ToSnippet(Type.Options.Default, type!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(type));
    }

    [Test]
    public async Task GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Constructor> constructors = [Create([])];
        Type type = OperatorsTestsData.Create();
        Type.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = constructors.ToSnippet(options!, type);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenValuesThenAnOrderedSnippetIsReturned()
    {
        // Arrange
        Type type = OperatorsTestsData.Create(name: "Test");

        Constructor publicMinimal = Create(parameters: []);
        Constructor publicWithParameter = Create(parameters: [ParameterTestsData.Create()]);

        Constructor protectedWithMultipleParameters = Create(
            parameters: [
                ParameterTestsData.Create(name: "Second"),
                ParameterTestsData.Create(name: "Third", modifier: Parameter.Mode.Params, type: typeof(Version[])),
                ParameterTestsData.Create(name: "First"),
            ],
            scope: Scope.Protected);

        ImmutableArray<Constructor> constructors =
        [
            publicWithParameter,
            protectedWithMultipleParameters,
            publicMinimal,
        ];

        const string expected = """
            public Test()
            {
                return default;
            }

            public Test(Version value)
            {
                return default;
            }

            protected Test(Version first, Version second, params Version[] third)
            {
                return default;
            }
            """;

        // Act
        var snippet = constructors.ToSnippet(Type.Options.Default, type);

        // Assert
        _ = await Assert.That(snippet.ToString()).IsEqualTo(expected);
    }

    private static Constructor Create(ImmutableArray<Parameter> parameters, Scope? scope = default)
    {
        return new Constructor
        {
            Body = OperatorsTestsData.DefaultBody,
            Extensibility = Extensibility.Implicit,
            Parameters = parameters,
            Scope = scope ?? Scope.Public,
        };
    }
}