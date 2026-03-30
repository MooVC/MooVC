namespace MooVC.Syntax.CSharp.ImplementationTests;

public sealed class WhenGetHashCodeIsCalled
{
    private const string Same = "IAlpha";
    private const string Different = "IBeta";

    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        Implementation first = new Declaration { Name = Same };
        Implementation second = new Declaration { Name = Different };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenMatchingValuesThenReturnsSameHash()
    {
        // Arrange
        Implementation first = new Declaration { Name = Same };
        Implementation second = new Declaration { Name = Same };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}