namespace MooVC.Syntax.CSharp.MonikerTests;

public sealed class WhenEqualsMonikerIsCalled
{
    [Test]
    public async Task GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Moniker subject = "Value";
        Moniker other = "Value";

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Moniker subject = "Value";
        Moniker? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}