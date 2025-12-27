namespace MooVC.Syntax.CSharp.Operators.BinaryTests.TypeTests;

public sealed class WhenPropertiesAreAccessed
{
    public static IEnumerable<object[]> Expectations()
    {
        yield return new object[]
        {
            new BinaryTypeExpectation(
                Binary.Type.Add,
                "+",
                true,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false),
        };

        yield return new object[]
        {
            new BinaryTypeExpectation(
                Binary.Type.And,
                "&",
                false,
                true,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false),
        };

        yield return new object[]
        {
            new BinaryTypeExpectation(
                Binary.Type.Divide,
                "/",
                false,
                false,
                true,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false),
        };

        yield return new object[]
        {
            new BinaryTypeExpectation(
                Binary.Type.Left,
                "<<",
                false,
                false,
                false,
                true,
                false,
                false,
                false,
                false,
                false,
                false,
                false),
        };

        yield return new object[]
        {
            new BinaryTypeExpectation(
                Binary.Type.Modulus,
                "%",
                false,
                false,
                false,
                false,
                true,
                false,
                false,
                false,
                false,
                false,
                false),
        };

        yield return new object[]
        {
            new BinaryTypeExpectation(
                Binary.Type.Multiply,
                "*",
                false,
                false,
                false,
                false,
                false,
                true,
                false,
                false,
                false,
                false,
                false),
        };

        yield return new object[]
        {
            new BinaryTypeExpectation(
                Binary.Type.Or,
                "|",
                false,
                false,
                false,
                false,
                false,
                false,
                true,
                false,
                false,
                false,
                false),
        };

        yield return new object[]
        {
            new BinaryTypeExpectation(
                Binary.Type.Right,
                ">>",
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                true,
                false,
                false,
                false),
        };

        yield return new object[]
        {
            new BinaryTypeExpectation(
                Binary.Type.Subtract,
                "-",
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                true,
                false,
                false),
        };

        yield return new object[]
        {
            new BinaryTypeExpectation(
                Binary.Type.Unspecified,
                string.Empty,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                true,
                false),
        };

        yield return new object[]
        {
            new BinaryTypeExpectation(
                Binary.Type.XOR,
                "^",
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                true),
        };
    }

    [Theory]
    [MemberData(nameof(Expectations))]
    public void GivenTypeThenFlagsReflectValue(BinaryTypeExpectation expectation)
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
        isAdd.ShouldBe(expectation.IsAdd);
        isAnd.ShouldBe(expectation.IsAnd);
        isDivide.ShouldBe(expectation.IsDivide);
        isLeft.ShouldBe(expectation.IsLeft);
        isModulus.ShouldBe(expectation.IsModulus);
        isMultiply.ShouldBe(expectation.IsMultiply);
        isOr.ShouldBe(expectation.IsOr);
        isRight.ShouldBe(expectation.IsRight);
        isSubtract.ShouldBe(expectation.IsSubtract);
        isUnspecified.ShouldBe(expectation.IsUnspecified);
        isXor.ShouldBe(expectation.IsXor);
        representation.ShouldBe(expectation.ExpectedString);
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