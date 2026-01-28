namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualsSymbolIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Base subject = new Symbol { Name = new Variable(Same) };
        Symbol? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var symbol = new Symbol { Name = new Variable(Same) };
        Base subject = symbol;
        Symbol other = symbol;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Base subject = new Symbol { Name = new Variable(Same) };
        var other = new Symbol { Name = new Variable(Same) };

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Base subject = new Symbol { Name = new Variable(Same) };
        var other = new Symbol { Name = new Variable(Different) };

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}