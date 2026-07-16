namespace MooVC.Syntax.CSharp.NaturesTests;

public sealed class WhenEqualsNaturesIsCalled
{
    private const string Same = "class";
    private const string Different = "struct";

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Natures left = Same;
        Natures right = Different;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Natures left = Same;
        Natures right = Same;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Natures subject = Same;
        Natures? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Natures subject = Same;
        Natures other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}