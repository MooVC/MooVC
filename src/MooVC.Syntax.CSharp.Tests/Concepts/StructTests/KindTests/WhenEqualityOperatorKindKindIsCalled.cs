namespace MooVC.Syntax.CSharp.Concepts.StructTests.KindTests;

public sealed class WhenEqualityOperatorKindKindIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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