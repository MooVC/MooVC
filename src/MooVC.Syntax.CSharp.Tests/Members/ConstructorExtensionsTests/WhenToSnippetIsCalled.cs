namespace MooVC.Syntax.CSharp.Members.ConstructorExtensionsTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Members.ParameterTests;
using MooVC.Syntax.CSharp.Operators;

public sealed class WhenToSnippetIsCalled
{
    private static readonly Snippet.Options options = Snippet.Options.Default
        .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Constructor> constructors = isDefault
            ? default
            : [];

        Type type = OperatorsTestsData.Create();

        // Act
        var snippet = constructors.ToSnippet(options, type);

        // Assert
        snippet.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullConstructThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Constructor> constructors = [Create([])];
        OperatorsTestsData.TestType? type = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = constructors.ToSnippet(options, type!));

        // Assert
        exception.ParamName.ShouldBe(nameof(type));
    }

    [Fact]
    public void GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Constructor> constructors = [Create([])];
        Type type = OperatorsTestsData.Create();
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = constructors.ToSnippet(options!, type));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenValuesThenAnOrderedSnippetIsReturned()
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
        var snippet = constructors.ToSnippet(options, type);

        // Assert
        snippet.ToString().ShouldBe(expected);
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