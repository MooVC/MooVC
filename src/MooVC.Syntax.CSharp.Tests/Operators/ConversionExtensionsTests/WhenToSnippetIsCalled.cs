namespace MooVC.Syntax.CSharp.Operators.ConversionExtensionsTests;

using System;
using System.Collections.Immutable;
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

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Conversion> conversions = isDefault
            ? default
            : [];

        OperatorsTestsData.TestType type = OperatorsTestsData.Create();

        // Act
        var result = conversions.ToSnippet(Snippet.Options.Default, type);

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.Empty);
    }

    [Test]
    public async Task GivenNullConstructThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Conversion> conversions = [ConversionTestsData.Create()];
        OperatorsTestsData.TestType? type = default;

        // Act
        Func<Snippet> act = () => _ = conversions.ToSnippet(Snippet.Options.Default, type!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(type));
    }

    [Test]
    public async Task GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Conversion> conversions = [ConversionTestsData.Create()];
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();
        Snippet.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = conversions.ToSnippet(options!, type);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenValuesThenAnOrderedSnippetIsReturned()
    {
        // Arrange
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();
        Conversion publicAlphaTo = ConversionTestsData.Create(scope: Scope.Public, subject: new Symbol { Name = "Alpha" });
        Conversion publicAlphaFrom = ConversionTestsData.Create(direction: Conversion.Intent.From, scope: Scope.Public, subject: new Symbol { Name = "Alpha" });
        Conversion protectedBetaTo = ConversionTestsData.Create(scope: Scope.Protected, subject: new Symbol { Name = "Beta" });

        ImmutableArray<Conversion> conversions = [protectedBetaTo, publicAlphaFrom, publicAlphaTo];

        // Act
        var snippet = conversions.ToSnippet(Snippet.Options.Default, type);

        // Assert
        _ = await Assert.That(snippet.ToString()).IsEqualTo(GivenValuesThenAnOrderedSnippetIsReturnedExpected);
    }
}