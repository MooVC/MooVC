namespace MooVC.Syntax.CSharp.Concepts.StructTests.KindTests;

public sealed class WhenInequalityOperatorKindStringIsCalled
{
    [Fact]
    public void GivenKindMatchesStringThenReturnsFalse()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Record;
        const string Right = "record";

        // Act
        bool resultLeftRight = left != Right;
        bool resultRightLeft = Right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenKindDiffersFromStringThenReturnsTrue()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Ref;
        const string Right = "readonly";

        // Act
        bool resultLeftRight = left != Right;
        bool resultRightLeft = Right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenNullKindThenReturnsFalseWhenComparedToNull()
    {
        // Arrange
        Struct.Kind left = default!;

        // Act
        bool result = left != null;

        // Assert
        result.ShouldBeFalse();
    }
}