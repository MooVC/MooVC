namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenGetHashCodeIsCalled
{
    private const string Same = "IAlpha";
    private const string Different = "IBeta";

    [Fact]
    public void GivenMatchingValuesThenReturnsSameHash()
    {
        // Arrange
        Interface first = new Declaration { Name = Same };
        Interface second = new Declaration { Name = Same };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        Interface first = new Declaration { Name = Same };
        Interface second = new Declaration { Name = Different };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}