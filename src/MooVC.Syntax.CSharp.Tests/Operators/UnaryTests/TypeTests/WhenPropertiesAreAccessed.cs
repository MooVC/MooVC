namespace MooVC.Syntax.CSharp.Operators.UnaryTests.TypeTests;

public sealed class WhenPropertiesAreAccessed
{
    public static TheoryData<UnaryTypeExpectation> Expectations()
    {
        return
        [
            new(Unary.Type.Complement, "~", true, false, false, false, false, false, false, false, false),
            new(Unary.Type.Decrement, "--", false, true, false, false, false, false, false, false, false),
            new(Unary.Type.False, "false", false, false, true, false, false, false, false, false, false),
            new(Unary.Type.Increment, "++", false, false, false, true, false, false, false, false, false),
            new(Unary.Type.Minus, "-", false, false, false, false, true, false, false, false, false),
            new(Unary.Type.Not, "!", false, false, false, false, false, true, false, false, false),
            new(Unary.Type.Plus, "+", false, false, false, false, false, false, true, false, false),
            new(Unary.Type.True, "true", false, false, false, false, false, false, false, true, false),
            new(Unary.Type.Unspecified, string.Empty, false, false, false, false, false, false, false, false, true),
        ];
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