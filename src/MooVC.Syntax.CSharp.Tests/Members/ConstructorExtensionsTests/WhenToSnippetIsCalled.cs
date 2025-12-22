namespace MooVC.Syntax.CSharp.Members.ConstructorExtensionsTests;

using System;
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

        Construct construct = OperatorsTestsData.CreateConstruct();

        // Act
        var snippet = constructors.ToSnippet(construct, options);

        // Assert
        snippet.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullConstructThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Constructor> constructors = [Create([])];
        OperatorsTestsData.TestConstruct? construct = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = constructors.ToSnippet(construct!, options));

        // Assert
        exception.ParamName.ShouldBe(nameof(construct));
    }

    [Fact]
    public void GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Constructor> constructors = [Create([])];
        Construct construct = OperatorsTestsData.CreateConstruct();
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = constructors.ToSnippet(construct, options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenValuesThenAnOrderedSnippetIsReturned()
    {
        // Arrange
        Construct construct = OperatorsTestsData.CreateConstruct();

        Constructor publicMinimal = Create(parameters: []);
        Constructor publicWithParameter = Create(parameters: [ParameterTestsData.Create()]);

        Constructor protectedWithMultipleParameters = Create(
            parameters: [
                ParameterTestsData.Create(name: "Second"),
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
            public First()
            {
                return default;
            }

            public Second(Version value)
            {
                return default;
            }

            protected Third(Version second, Version first)
            {
                return default;
            }
            """;

        // Act
        var snippet = constructors.ToSnippet(construct, options);

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