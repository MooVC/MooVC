namespace MooVC.Syntax.CSharp.BaseTests;

public sealed class WhenGetHashCodeIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Test]
    public async Task GivenMatchingBasesThenReturnSameHash()
    {
        // Arrange
        Base first = new Symbol { Name = Same };
        Base second = new Symbol { Name = Same };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentBasesThenReturnDifferentHashes()
    {
        // Arrange
        Base first = new Symbol { Name = Same };
        Base second = new Symbol { Name = Different };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }
}