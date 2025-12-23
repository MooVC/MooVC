namespace MooVC.Syntax.CSharp.Operators.UnaryTests.TypeTests;

public sealed class WhenPropertiesAreAccessed
{
    public static IEnumerable<object[]> Expectations()
    {
        yield return new object[]
        {
            new UnaryTypeExpectation(
                operatorType: Unary.Type.Complement,
                expectedString: "~",
                isComplement: true,
                isDecrement: false,
                isFalse: false,
                isIncrement: false,
                isMinus: false,
                isNot: false,
                isPlus: false,
                isTrue: false,
                isUnspecified: false),
        };

        yield return new object[]
        {
            new UnaryTypeExpectation(
                operatorType: Unary.Type.Decrement,
                expectedString: "--",
                isComplement: false,
                isDecrement: true,
                isFalse: false,
                isIncrement: false,
                isMinus: false,
                isNot: false,
                isPlus: false,
                isTrue: false,
                isUnspecified: false),
        };

        yield return new object[]
        {
            new UnaryTypeExpectation(
                operatorType: Unary.Type.False,
                expectedString: "false",
                isComplement: false,
                isDecrement: false,
                isFalse: true,
                isIncrement: false,
                isMinus: false,
                isNot: false,
                isPlus: false,
                isTrue: false,
                isUnspecified: false),
        };

        yield return new object[]
        {
            new UnaryTypeExpectation(
                operatorType: Unary.Type.Increment,
                expectedString: "++",
                isComplement: false,
                isDecrement: false,
                isFalse: false,
                isIncrement: true,
                isMinus: false,
                isNot: false,
                isPlus: false,
                isTrue: false,
                isUnspecified: false),
        };

        yield return new object[]
        {
            new UnaryTypeExpectation(
                operatorType: Unary.Type.Minus,
                expectedString: "-",
                isComplement: false,
                isDecrement: false,
                isFalse: false,
                isIncrement: false,
                isMinus: true,
                isNot: false,
                isPlus: false,
                isTrue: false,
                isUnspecified: false),
        };

        yield return new object[]
        {
            new UnaryTypeExpectation(
                operatorType: Unary.Type.Not,
                expectedString: "!",
                isComplement: false,
                isDecrement: false,
                isFalse: false,
                isIncrement: false,
                isMinus: false,
                isNot: true,
                isPlus: false,
                isTrue: false,
                isUnspecified: false),
        };

        yield return new object[]
        {
            new UnaryTypeExpectation(
                operatorType: Unary.Type.Plus,
                expectedString: "+",
                isComplement: false,
                isDecrement: false,
                isFalse: false,
                isIncrement: false,
                isMinus: false,
                isNot: false,
                isPlus: true,
                isTrue: false,
                isUnspecified: false),
        };

        yield return new object[]
        {
            new UnaryTypeExpectation(
                operatorType: Unary.Type.True,
                expectedString: "true",
                isComplement: false,
                isDecrement: false,
                isFalse: false,
                isIncrement: false,
                isMinus: false,
                isNot: false,
                isPlus: false,
                isTrue: true,
                isUnspecified: false),
        };

        yield return new object[]
        {
            new UnaryTypeExpectation(
                operatorType: Unary.Type.Unspecified,
                expectedString: string.Empty,
                isComplement: false,
                isDecrement: false,
                isFalse: false,
                isIncrement: false,
                isMinus: false,
                isNot: false,
                isPlus: false,
                isTrue: false,
                isUnspecified: true),
        };
    }

    [Theory]
    [MemberData(nameof(Expectations))]
    public void GivenTypeThenFlagsReflectValue(UnaryTypeExpectation expectation)
    {
        // Arrange
        Unary.Type subject = expectation.OperatorType;

        // Act
        bool isComplement = subject.IsComplement;
        bool isDecrement = subject.IsDecrement;
        bool isFalse = subject.IsFalse;
        bool isIncrement = subject.IsIncrement;
        bool isMinus = subject.IsMinus;
        bool isNot = subject.IsNot;
        bool isPlus = subject.IsPlus;
        bool isTrue = subject.IsTrue;
        bool isUnspecified = subject.IsUnspecified;
        string representation = subject.ToString();

        // Assert
        isComplement.ShouldBe(expectation.IsComplement);
        isDecrement.ShouldBe(expectation.IsDecrement);
        isFalse.ShouldBe(expectation.IsFalse);
        isIncrement.ShouldBe(expectation.IsIncrement);
        isMinus.ShouldBe(expectation.IsMinus);
        isNot.ShouldBe(expectation.IsNot);
        isPlus.ShouldBe(expectation.IsPlus);
        isTrue.ShouldBe(expectation.IsTrue);
        isUnspecified.ShouldBe(expectation.IsUnspecified);
        representation.ShouldBe(expectation.ExpectedString);
    }

    public sealed record UnaryTypeExpectation(
        Unary.Type OperatorType,
        string ExpectedString,
        bool IsComplement,
        bool IsDecrement,
        bool IsFalse,
        bool IsIncrement,
        bool IsMinus,
        bool IsNot,
        bool IsPlus,
        bool IsTrue,
        bool IsUnspecified);
}
