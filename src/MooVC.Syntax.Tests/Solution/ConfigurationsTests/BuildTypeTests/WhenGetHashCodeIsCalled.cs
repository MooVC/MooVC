namespace MooVC.Syntax.Solution.ConfigurationsTests.BuildTypeTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        var first = new Configurations.BuildType("Custom");
        var second = new Configurations.BuildType("Other");

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenEqualValuesThenHashesMatch()
    {
        // Arrange
        var first = new Configurations.BuildType("Custom");
        var second = new Configurations.BuildType("Custom");

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}