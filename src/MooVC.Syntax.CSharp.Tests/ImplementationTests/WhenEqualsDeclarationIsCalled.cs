namespace MooVC.Syntax.CSharp.ImplementationTests;

public sealed class WhenEqualsDeclarationIsCalled
{
    private const string Same = "IAlpha";
    private const string Different = "IBeta";

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Implementation subject = new Declaration { Name = Same };
        Declaration? other = default;

        // Act
        bool resultLeftRight = subject.Equals(other);
        bool resultRightLeft = other?.Equals(subject) ?? false;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Implementation left = new Declaration { Name = Same };
        var right = new Declaration { Name = Same };

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Implementation left = new Declaration { Name = Same };
        var right = new Declaration { Name = Different };

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }
}