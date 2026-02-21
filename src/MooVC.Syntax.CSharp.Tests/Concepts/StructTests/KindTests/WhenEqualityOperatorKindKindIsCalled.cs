namespace MooVC.Syntax.CSharp.Concepts.StructTests.KindTests;

public sealed class WhenEqualityOperatorKindKindIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Struct.Kind? left = default;
        Struct.Kind? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Record;
        Struct.Kind right = left;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Record;
        Struct.Kind right = Struct.Kind.Record;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.ReadOnly;
        Struct.Kind right = Struct.Kind.Record;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}