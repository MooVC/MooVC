namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualsBaseIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Base subject = new Symbol { Name = Same };
        Base? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Base subject = new Symbol { Name = Same };
        Base other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Base left = new Symbol { Name = Same };
        Base right = new Symbol { Name = Same };

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Base left = new Symbol { Name = Same };
        Base right = new Symbol { Name = Different };

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }
}