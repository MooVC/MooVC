namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenPropertiesAreAccessed
{
    public static IEnumerable<object[]> Expectations()
    {
        yield return new object[]
        {
            new ComparisonTypeExpectation(
                operatorType: Comparison.Type.Equality,
                expectedString: "==",
                isEquality: true,
                isGreaterThan: false,
                isGreaterThanOrEqual: false,
                isInequality: false,
                isLessThan: false,
                isLessThanOrEqual: false,
                isUnspecified: false),
        };

        yield return new object[]
        {
            new ComparisonTypeExpectation(
                operatorType: Comparison.Type.GreaterThan,
                expectedString: ">",
                isEquality: false,
                isGreaterThan: true,
                isGreaterThanOrEqual: false,
                isInequality: false,
                isLessThan: false,
                isLessThanOrEqual: false,
                isUnspecified: false),
        };

        yield return new object[]
        {
            new ComparisonTypeExpectation(
                operatorType: Comparison.Type.GreaterThanOrEqual,
                expectedString: ">=",
                isEquality: false,
                isGreaterThan: false,
                isGreaterThanOrEqual: true,
                isInequality: false,
                isLessThan: false,
                isLessThanOrEqual: false,
                isUnspecified: false),
        };

        yield return new object[]
        {
            new ComparisonTypeExpectation(
                operatorType: Comparison.Type.Inequality,
                expectedString: "!=",
                isEquality: false,
                isGreaterThan: false,
                isGreaterThanOrEqual: false,
                isInequality: true,
                isLessThan: false,
                isLessThanOrEqual: false,
                isUnspecified: false),
        };

        yield return new object[]
        {
            new ComparisonTypeExpectation(
                operatorType: Comparison.Type.LessThan,
                expectedString: "<",
                isEquality: false,
                isGreaterThan: false,
                isGreaterThanOrEqual: false,
                isInequality: false,
                isLessThan: true,
                isLessThanOrEqual: false,
                isUnspecified: false),
        };

        yield return new object[]
        {
            new ComparisonTypeExpectation(
                operatorType: Comparison.Type.LessThanOrEqual,
                expectedString: "<=",
                isEquality: false,
                isGreaterThan: false,
                isGreaterThanOrEqual: false,
                isInequality: false,
                isLessThan: false,
                isLessThanOrEqual: true,
                isUnspecified: false),
        };

        yield return new object[]
        {
            new ComparisonTypeExpectation(
                operatorType: Comparison.Type.Unspecified,
                expectedString: string.Empty,
                isEquality: false,
                isGreaterThan: false,
                isGreaterThanOrEqual: false,
                isInequality: false,
                isLessThan: false,
                isLessThanOrEqual: false,
                isUnspecified: true),
        };
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
