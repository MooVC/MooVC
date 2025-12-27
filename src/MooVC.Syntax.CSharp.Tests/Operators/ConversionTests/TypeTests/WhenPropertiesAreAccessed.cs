namespace MooVC.Syntax.CSharp.Operators.ConversionTests.TypeTests;

public sealed class WhenPropertiesAreAccessed
{
    public static TheoryData<ConversionTypeExpectation> Expectations()
    {
        return
        [
            new(Conversion.Type.Explicit, "explicit", true, false),
            new(Conversion.Type.Implicit, "implicit", false, true),
        ];
    }

    [Theory]
    [MemberData(nameof(Expectations))]
    public void GivenTypeThenFlagsReflectValue(ConversionTypeExpectation expectation)
    {
        // Arrange
        Conversion.Type subject = expectation.OperatorType;

        // Act
        bool isExplicit = subject.IsExplicit;
        bool isImplicit = subject.IsImplicit;
        string representation = subject.ToString();

        // Assert
        isExplicit.ShouldBe(expectation.IsExplicit);
        isImplicit.ShouldBe(expectation.IsImplicit);
        representation.ShouldBe(expectation.ExpectedString);
    }

    public sealed record ConversionTypeExpectation(
        Conversion.Type OperatorType,
        string ExpectedString,
        bool IsExplicit,
        bool IsImplicit);
}