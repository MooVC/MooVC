namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenPropertiesAreAccessed
{
    public static IEnumerable<ComparisonTypeExpectation> GivenTypeThenFlagsReflectValueData()
    {
        return
        [
            new(Comparison.Type.Equality, "==", true, false, false, false, false, false, false),
            new(Comparison.Type.GreaterThan, ">", false, true, false, false, false, false, false),
            new(Comparison.Type.GreaterThanOrEqual, ">=", false, false, true, false, false, false, false),
            new(Comparison.Type.Inequality, "!=", false, false, false, true, false, false, false),
            new(Comparison.Type.LessThan, "<", false, false, false, false, true, false, false),
            new(Comparison.Type.LessThanOrEqual, "<=", false, false, false, false, false, true, false),
            new(Comparison.Type.Unspecified, string.Empty, false, false, false, false, false, false, true),
        ];
    }

    [Test]
    [MethodDataSource(nameof(GivenTypeThenFlagsReflectValueData))]
    public async Task GivenTypeThenFlagsReflectValue(ComparisonTypeExpectation expectation)
    {
        // Arrange
        Comparison.Type subject = expectation.OperatorType;

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
        await Assert.That(isEquality).IsEqualTo(expectation.IsEquality);
        await Assert.That(isGreaterThan).IsEqualTo(expectation.IsGreaterThan);
        await Assert.That(isGreaterThanOrEqual).IsEqualTo(expectation.IsGreaterThanOrEqual);
        await Assert.That(isInequality).IsEqualTo(expectation.IsInequality);
        await Assert.That(isLessThan).IsEqualTo(expectation.IsLessThan);
        await Assert.That(isLessThanOrEqual).IsEqualTo(expectation.IsLessThanOrEqual);
        await Assert.That(isUnspecified).IsEqualTo(expectation.IsUnspecified);
        await Assert.That(representation).IsEqualTo(expectation.ExpectedString);
    }

    public sealed record ComparisonTypeExpectation(
        Comparison.Type OperatorType,
        string ExpectedString,
        bool IsEquality,
        bool IsGreaterThan,
        bool IsGreaterThanOrEqual,
        bool IsInequality,
        bool IsLessThan,
        bool IsLessThanOrEqual,
        bool IsUnspecified);
}