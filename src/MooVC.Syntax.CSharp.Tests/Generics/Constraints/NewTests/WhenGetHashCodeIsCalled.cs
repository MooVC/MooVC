namespace MooVC.Syntax.CSharp.Generics.Constraints.NewTests;

public sealed class WhenGetHashCodeIsCalled
{
    private const string Same = "new()";
    private const string Different = "";

    [Fact]
    public void GivenMatchingValuesThenReturnsSameHash()
    {
        // Arrange
        New first = Same;
        New second = Same;

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
        New first = Same;
        New second = Different;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}
