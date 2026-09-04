namespace MooVC.Syntax.CSharp.ComparisonTests.TypesTests;

public sealed class WhenPropertiesAreAccessed
{
    public static IEnumerable<ComparisonTypeExpectation> GivenTypeThenFlagsReflectValueData()
    {
        return
        [
            new(Comparison.Types.Equality, "==", true, false, false, false, false, false, false),
            new(Comparison.Types.GreaterThan, ">", false, true, false, false, false, false, false),
            new(Comparison.Types.GreaterThanOrEqual, ">=", false, false, true, false, false, false, false),
            new(Comparison.Types.Inequality, "!=", false, false, false, true, false, false, false),
            new(Comparison.Types.LessThan, "<", false, false, false, false, true, false, false),
            new(Comparison.Types.LessThanOrEqual, "<=", false, false, false, false, false, true, false),
            new(Comparison.Types.Unspecified, string.Empty, false, false, false, false, false, false, true),
        ];
    }

    [Test]
    [MethodDataSource(nameof(GivenTypeThenFlagsReflectValueData))]
    public async Task GivenTypeThenFlagsReflectValue(ComparisonTypeExpectation expectation)
    {
        // Arrange
        Comparison.Types subject = expectation.OperatorType;

        // Act
        bool isEquality = subject.IsEquality;
        bool isGreaterThan = subject.IsGreaterThan;
        bool isGreaterThanOrEqual = subject.IsGreaterThanOrEqual;
        bool isInequality = subject.IsInequality;
        bool isLessThan = subject.IsLessThan;
        bool isLessThanOrEqual = subject.IsLessThanOrEqual;
        bool isUnspecified = subject.IsUnspecified;
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(isEquality).IsEqualTo(expectation.IsEquality);
        _ = await Assert.That(isGreaterThan).IsEqualTo(expectation.IsGreaterThan);
        _ = await Assert.That(isGreaterThanOrEqual).IsEqualTo(expectation.IsGreaterThanOrEqual);
        _ = await Assert.That(isInequality).IsEqualTo(expectation.IsInequality);
        _ = await Assert.That(isLessThan).IsEqualTo(expectation.IsLessThan);
        _ = await Assert.That(isLessThanOrEqual).IsEqualTo(expectation.IsLessThanOrEqual);
        _ = await Assert.That(isUnspecified).IsEqualTo(expectation.IsUnspecified);
        _ = await Assert.That(representation).IsEqualTo(expectation.ExpectedString);
    }

    public sealed record ComparisonTypeExpectation(
        Comparison.Types OperatorType,
        string ExpectedString,
        bool IsEquality,
        bool IsGreaterThan,
        bool IsGreaterThanOrEqual,
        bool IsInequality,
        bool IsLessThan,
        bool IsLessThanOrEqual,
        bool IsUnspecified);
}