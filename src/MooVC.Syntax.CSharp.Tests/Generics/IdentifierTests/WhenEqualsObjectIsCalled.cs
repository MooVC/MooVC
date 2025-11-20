namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenEqualsObjectIsCalled
{
    private const string Same = "TAlpha";
    private const string Different = "TBravo";

    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Identifier(Same);
        object? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var subject = new Identifier(Same);
        object other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Identifier(Same);
        object right = new Identifier(Same);

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Identifier(Same);
        object right = new Identifier(Different);

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenNonIdentifierThenReturnsFalse()
    {
        // Arrange
        var subject = new Identifier(Same);
        object other = Same;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}