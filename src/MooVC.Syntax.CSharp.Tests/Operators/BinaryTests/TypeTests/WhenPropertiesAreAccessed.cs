namespace MooVC.Syntax.CSharp.Operators.BinaryTests.TypeTests;

public sealed class WhenPropertiesAreAccessed
{
    public static IEnumerable<BinaryTypeExpectation> GivenTypeThenFlagsReflectValueData()
    {
        return
        [
            new(Binary.Type.Add, "+", true, false, false, false, false, false, false, false, false, false, false),
            new(Binary.Type.And, "&", false, true, false, false, false, false, false, false, false, false, false),
            new(Binary.Type.Divide, "/", false, false, true, false, false, false, false, false, false, false, false),
            new(Binary.Type.Left, "<<", false, false, false, true, false, false, false, false, false, false, false),
            new(Binary.Type.Modulus, "%", false, false, false, false, true, false, false, false, false, false, false),
            new(Binary.Type.Multiply, "*", false, false, false, false, false, true, false, false, false, false, false),
            new(Binary.Type.Or, "|", false, false, false, false, false, false, true, false, false, false, false),
            new(Binary.Type.Right, ">>", false, false, false, false, false, false, false, true, false, false, false),
            new(Binary.Type.Subtract, "-", false, false, false, false, false, false, false, false, true, false, false),
            new(Binary.Type.Unspecified, string.Empty, false, false, false, false, false, false, false, false, false, true, false),
            new(Binary.Type.XOR, "^", false, false, false, false, false, false, false, false, false, false, true),
        ];
    }

    [Test]
    [MethodDataSource(nameof(GivenTypeThenFlagsReflectValueData))]
    public async Task GivenTypeThenFlagsReflectValue(BinaryTypeExpectation expectation)
    {
        // Arrange
        Binary.Type subject = expectation.OperatorType;

        // Act
        bool isAdd = subject.IsAdd;
        bool isAnd = subject.IsAnd;
        bool isDivide = subject.IsDivide;
        bool isLeft = subject.IsLeft;
        bool isModulus = subject.IsModulus;
        bool isMultiply = subject.IsMultiply;
        bool isOr = subject.IsOr;
        bool isRight = subject.IsRight;
        bool isSubtract = subject.IsSubtract;
        bool isUnspecified = subject.IsUnspecified;
        bool isXor = subject.IsXOR;
        string representation = subject.ToString();

        // Assert
        await Assert.That(isAdd).IsEqualTo(expectation.IsAdd);
        await Assert.That(isAnd).IsEqualTo(expectation.IsAnd);
        await Assert.That(isDivide).IsEqualTo(expectation.IsDivide);
        await Assert.That(isLeft).IsEqualTo(expectation.IsLeft);
        await Assert.That(isModulus).IsEqualTo(expectation.IsModulus);
        await Assert.That(isMultiply).IsEqualTo(expectation.IsMultiply);
        await Assert.That(isOr).IsEqualTo(expectation.IsOr);
        await Assert.That(isRight).IsEqualTo(expectation.IsRight);
        await Assert.That(isSubtract).IsEqualTo(expectation.IsSubtract);
        await Assert.That(isUnspecified).IsEqualTo(expectation.IsUnspecified);
        await Assert.That(isXor).IsEqualTo(expectation.IsXor);
        await Assert.That(representation).IsEqualTo(expectation.ExpectedString);
    }

    public sealed record BinaryTypeExpectation(
        Binary.Type OperatorType,
        string ExpectedString,
        bool IsAdd,
        bool IsAnd,
        bool IsDivide,
        bool IsLeft,
        bool IsModulus,
        bool IsMultiply,
        bool IsOr,
        bool IsRight,
        bool IsSubtract,
        bool IsUnspecified,
        bool IsXor);
}