namespace MooVC.Syntax.CSharp.Generics.Constraints.NewTests;

public sealed class WhenGetHashCodeIsCalled
{
    private const string Same = "new()";
    private const string Different = "";

    [Test]
    public async Task GivenMatchingValuesThenReturnsSameHash()
    {
        // Arrange
        New first = Same;
        New second = Same;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        New first = Same;
        New second = Different;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }
}