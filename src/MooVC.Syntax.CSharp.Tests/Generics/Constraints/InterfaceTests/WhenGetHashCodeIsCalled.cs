namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenGetHashCodeIsCalled
{
    private const string Same = "IAlpha";
    private const string Different = "IBeta";

    [Test]
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

    [Test]
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