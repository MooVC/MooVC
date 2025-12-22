namespace MooVC.Syntax.CSharp.Concepts.StructTests.KindTests;

public sealed class WhenInequalityOperatorKindKindIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Struct.Kind? left = default;
        Struct.Kind? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Record;
        Struct.Kind right = Struct.Kind.Record;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Ref;
        Struct.Kind right = Struct.Kind.Record;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}