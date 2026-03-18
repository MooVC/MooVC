namespace MooVC.Syntax.CSharp.Concepts.StructTests.KindTests;

public sealed class WhenEqualityOperatorKindStringIsCalled
{
    [Test]
    public void GivenKindMatchesStringThenReturnsTrue()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Record;
        const string Right = "record";

        // Act
        bool result = left == Right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenKindDiffersFromStringThenReturnsFalse()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Ref;
        const string Right = "readonly";

        // Act
        bool result = left == Right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenNullKindThenMatchesOnlyNullOrEmptyStrings()
    {
        // Arrange
        Struct.Kind left = default!;

        // Act
        bool result = left == default(string);

        // Assert
        result.ShouldBeTrue();
    }
}