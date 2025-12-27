namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualsObjectIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Base subject = new Symbol { Name = new Identifier(Same) };
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
        Base subject = new Symbol { Name = new Identifier(Same) };
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
        Base left = new Symbol { Name = new Identifier(Same) };
        object right = new Base(new Symbol { Name = new Identifier(Same) });

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Base left = new Symbol { Name = new Identifier(Same) };
        object right = new Symbol { Name = new Identifier(Different) };

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenNonBaseThenReturnsFalse()
    {
        // Arrange
        Base subject = new Symbol { Name = new Identifier(Same) };
        object other = new Symbol { Name = new Identifier(Same) };

        // Act
        bool result = subject.Equals(other.ToString());

        // Assert
        result.ShouldBeFalse();
    }
}