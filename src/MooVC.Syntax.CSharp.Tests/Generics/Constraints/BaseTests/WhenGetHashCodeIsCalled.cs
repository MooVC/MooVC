namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenGetHashCodeIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Fact]
    public void GivenMatchingBasesThenReturnSameHash()
    {
        // Arrange
        Base first = new Symbol { Name = Same };
        Base second = new Symbol { Name = Same };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Fact]
    public void GivenDifferentBasesThenReturnDifferentHashes()
    {
        // Arrange
        Base first = new Symbol { Name = Same };
        Base second = new Symbol { Name = Different };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}