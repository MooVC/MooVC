namespace MooVC.Syntax.CSharp.BaseTests;

public sealed class WhenEqualsBaseIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Base left = new Symbol { Name = Same };
        Base right = new Symbol { Name = Different };

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Base left = new Symbol { Name = Same };
        Base right = new Symbol { Name = Same };

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Base subject = new Symbol { Name = Same };
        Base? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Base subject = new Symbol { Name = Same };
        Base other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}