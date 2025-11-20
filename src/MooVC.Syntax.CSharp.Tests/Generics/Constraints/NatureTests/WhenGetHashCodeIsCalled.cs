namespace MooVC.Syntax.CSharp.Generics.Constraints.NatureTests;

public sealed class WhenGetHashCodeIsCalled
{
    private const string Same = "class";
    private const string Different = "struct";

    [Fact]
    public void GivenMatchingValuesThenReturnsSameHash()
    {
        // Arrange
        Nature first = Same;
        Nature second = Same;

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
        Nature first = Same;
        Nature second = Different;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}
