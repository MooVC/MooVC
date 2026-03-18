namespace MooVC.Syntax.CSharp.Operators.UnaryTests.TypeTests;

public sealed class WhenPropertiesAreAccessed
{
    public static IEnumerable<UnaryTypeExpectation> GivenTypeThenFlagsReflectValueData()
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

    [Test]
    [MethodDataSource(nameof(GivenTypeThenFlagsReflectValueData))]
    public async Task GivenTypeThenFlagsReflectValue(UnaryTypeExpectation expectation)
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
        _ = await Assert.That(isComplement).IsEqualTo(expectation.IsComplement);
        _ = await Assert.That(isDecrement).IsEqualTo(expectation.IsDecrement);
        _ = await Assert.That(isFalse).IsEqualTo(expectation.IsFalse);
        _ = await Assert.That(isIncrement).IsEqualTo(expectation.IsIncrement);
        _ = await Assert.That(isMinus).IsEqualTo(expectation.IsMinus);
        _ = await Assert.That(isNot).IsEqualTo(expectation.IsNot);
        _ = await Assert.That(isPlus).IsEqualTo(expectation.IsPlus);
        _ = await Assert.That(isTrue).IsEqualTo(expectation.IsTrue);
        _ = await Assert.That(isUnspecified).IsEqualTo(expectation.IsUnspecified);
        _ = await Assert.That(representation).IsEqualTo(expectation.ExpectedString);
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