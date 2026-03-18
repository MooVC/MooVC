namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenEqualsStringIsCalled
{
    private const string Same = "TAlpha";
    private const string Different = "TBravo";

    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Identifier(Same);
        string? other = default;

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
        string other = Same;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var subject = new Identifier(Same);
        string other = Same;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Identifier(Same);
        string other = Different;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}