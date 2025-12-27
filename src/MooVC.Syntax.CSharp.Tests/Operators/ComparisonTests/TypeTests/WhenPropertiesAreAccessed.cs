namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenPropertiesAreAccessed
{
    public static TheoryData<ComparisonTypeExpectation> Expectations()
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

    [Theory]
    [MemberData(nameof(Expectations))]
    public void GivenTypeThenFlagsReflectValue(ComparisonTypeExpectation expectation)
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
        isEquality.ShouldBe(expectation.IsEquality);
        isGreaterThan.ShouldBe(expectation.IsGreaterThan);
        isGreaterThanOrEqual.ShouldBe(expectation.IsGreaterThanOrEqual);
        isInequality.ShouldBe(expectation.IsInequality);
        isLessThan.ShouldBe(expectation.IsLessThan);
        isLessThanOrEqual.ShouldBe(expectation.IsLessThanOrEqual);
        isUnspecified.ShouldBe(expectation.IsUnspecified);
        representation.ShouldBe(expectation.ExpectedString);
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