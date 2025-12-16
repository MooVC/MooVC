namespace MooVC.Syntax.CSharp.Concepts.StructTests;

public sealed class WhenEqualityOperatorKindStringIsCalled
{
    [Fact]
    public void GivenKindMatchesStringThenReturnsTrue()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Record;
        const string Right = "record";

        // Act
        bool resultLeftRight = left == Right;
        bool resultRightLeft = Right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenKindDiffersFromStringThenReturnsFalse()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Ref;
        const string Right = "readonly";

        // Act
        bool resultLeftRight = left == Right;
        bool resultRightLeft = Right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenNullKindThenMatchesOnlyNullOrEmptyStrings()
    {
        // Arrange
        Struct.Kind left = default!;

        // Act
        bool resultNull = left == null;
        bool resultEmpty = left == string.Empty;

        // Assert
        resultNull.ShouldBeTrue();
        resultEmpty.ShouldBeFalse();
    }
}
