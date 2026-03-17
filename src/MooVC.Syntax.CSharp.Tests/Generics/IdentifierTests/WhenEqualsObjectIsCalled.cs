namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenEqualsObjectIsCalled
{
    private const string Same = "TAlpha";
    private const string Different = "TBravo";

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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