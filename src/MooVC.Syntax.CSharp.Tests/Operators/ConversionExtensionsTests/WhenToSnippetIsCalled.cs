namespace MooVC.Syntax.CSharp.Operators.ConversionExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Operators.ConversionTests;

public sealed class WhenToSnippetIsCalled
{
    private const string GivenValuesThenAnOrderedSnippetIsReturnedExpected = """
        public static implicit operator Alpha(Value subject)
        {
            return new Value();
        }

        public static implicit operator Value(Alpha subject)
        {
            return new Value();
        }

        protected static implicit operator Beta(Value subject)
        {
            return new Value();
        }
        """;

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Conversion> conversions = isDefault
            ? default
            : ImmutableArray<Conversion>.Empty;

        OperatorsTestsData.TestConstruct construct = OperatorsTestsData.CreateConstruct();

        // Act
        var result = conversions.ToSnippet(construct, Snippet.Options.Default);

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullConstructThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Conversion> conversions = [ConversionTestsData.Create()];
        OperatorsTestsData.TestConstruct? construct = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = conversions.ToSnippet(construct!, Snippet.Options.Default));

        // Assert
        exception.ParamName.ShouldBe(nameof(construct));
    }

    [Fact]
    public void GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Conversion> conversions = [ConversionTestsData.Create()];
        OperatorsTestsData.TestConstruct construct = OperatorsTestsData.CreateConstruct();
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = conversions.ToSnippet(construct, options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenValuesThenAnOrderedSnippetIsReturned()
    {
        // Arrange
        OperatorsTestsData.TestConstruct construct = OperatorsTestsData.CreateConstruct();

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        Conversion publicAlphaTo = ConversionTestsData.Create(scope: Scope.Public, subject: new Symbol { Name = "Alpha" });
        Conversion publicAlphaFrom = ConversionTestsData.Create(direction: Conversion.Intent.From, scope: Scope.Public, subject: new Symbol { Name = "Alpha" });
        Conversion protectedBetaTo = ConversionTestsData.Create(scope: Scope.Protected, subject: new Symbol { Name = "Beta" });

        ImmutableArray<Conversion> conversions = [protectedBetaTo, publicAlphaFrom, publicAlphaTo];

        // Act
        var snippet = conversions.ToSnippet(construct, options);

        // Assert
        snippet.ToString().ShouldBe(GivenValuesThenAnOrderedSnippetIsReturnedExpected);
    }
}