namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.BuildTypeTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public void GivenEqualValuesThenHashesMatch()
    {
        // Arrange
        var first = new Configurations.BuildType("Custom");
        var second = new Configurations.BuildType("Custom");

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Test]
    public void GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        var first = new Configurations.BuildType("Custom");
        var second = new Configurations.BuildType("Other");

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}