namespace MooVC.Syntax.CSharp.MonikerTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Moniker subject = "Value";
        object other = (Moniker)"Value";

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        Moniker subject = "Value";
        object other = "Value";

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}