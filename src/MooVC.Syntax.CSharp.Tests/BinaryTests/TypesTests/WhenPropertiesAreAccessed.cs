namespace MooVC.Syntax.CSharp.BinaryTests.TypesTests;

public sealed class WhenPropertiesAreAccessed
{
    public static IEnumerable<BinaryTypeExpectation> GivenTypeThenFlagsReflectValueData()
    {
        return
        [
            new(Binary.Types.Add, "+", true, false, false, false, false, false, false, false, false, false, false),
            new(Binary.Types.And, "&", false, true, false, false, false, false, false, false, false, false, false),
            new(Binary.Types.Divide, "/", false, false, true, false, false, false, false, false, false, false, false),
            new(Binary.Types.Left, "<<", false, false, false, true, false, false, false, false, false, false, false),
            new(Binary.Types.Modulus, "%", false, false, false, false, true, false, false, false, false, false, false),
            new(Binary.Types.Multiply, "*", false, false, false, false, false, true, false, false, false, false, false),
            new(Binary.Types.Or, "|", false, false, false, false, false, false, true, false, false, false, false),
            new(Binary.Types.Right, ">>", false, false, false, false, false, false, false, true, false, false, false),
            new(Binary.Types.Subtract, "-", false, false, false, false, false, false, false, false, true, false, false),
            new(Binary.Types.Unspecified, string.Empty, false, false, false, false, false, false, false, false, false, true, false),
            new(Binary.Types.XOR, "^", false, false, false, false, false, false, false, false, false, false, true),
        ];
    }

    [Test]
    [MethodDataSource(nameof(GivenTypeThenFlagsReflectValueData))]
    public async Task GivenTypeThenFlagsReflectValue(BinaryTypeExpectation expectation)
    {
        // Arrange
        Binary.Types subject = expectation.OperatorType;

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
        _ = await Assert.That(isAdd).IsEqualTo(expectation.IsAdd);
        _ = await Assert.That(isAnd).IsEqualTo(expectation.IsAnd);
        _ = await Assert.That(isDivide).IsEqualTo(expectation.IsDivide);
        _ = await Assert.That(isLeft).IsEqualTo(expectation.IsLeft);
        _ = await Assert.That(isModulus).IsEqualTo(expectation.IsModulus);
        _ = await Assert.That(isMultiply).IsEqualTo(expectation.IsMultiply);
        _ = await Assert.That(isOr).IsEqualTo(expectation.IsOr);
        _ = await Assert.That(isRight).IsEqualTo(expectation.IsRight);
        _ = await Assert.That(isSubtract).IsEqualTo(expectation.IsSubtract);
        _ = await Assert.That(isUnspecified).IsEqualTo(expectation.IsUnspecified);
        _ = await Assert.That(isXor).IsEqualTo(expectation.IsXor);
        _ = await Assert.That(representation).IsEqualTo(expectation.ExpectedString);
    }

    public sealed record BinaryTypeExpectation(
        Binary.Types OperatorType,
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