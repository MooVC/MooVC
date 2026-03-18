namespace MooVC.Syntax.CSharp.Generics.Constraints.NewTests;

public sealed class WhenEqualsNewIsCalled
{
    private const string Same = "new()";
    private const string Different = "";

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        New subject = Same;
        New? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        New subject = Same;
        New other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        New left = Same;
        New right = Same;

        // Act
        bool result = left.Equals(right);

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        New left = Same;
        New right = Different;

        // Act
        bool result = left.Equals(right);

        // Assert
        await Assert.That(result).IsFalse();
    }
}