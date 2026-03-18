namespace MooVC.Syntax.Resource.AssemblyTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Assembly subject = AssemblyTestsData.Create();

        // Act
        bool result = subject.Equals(null);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        Assembly subject = AssemblyTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Assembly subject = AssemblyTestsData.Create();
        object other = AssemblyTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}