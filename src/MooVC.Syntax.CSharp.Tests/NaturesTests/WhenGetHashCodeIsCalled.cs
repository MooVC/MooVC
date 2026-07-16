namespace MooVC.Syntax.CSharp.NaturesTests;

public sealed class WhenGetHashCodeIsCalled
{
    private const string Same = "class";
    private const string Different = "struct";

    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        Natures first = Same;
        Natures second = Different;

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
        Argument.Modes first = Argument.Modes.Ref;
        Argument.Modes second = Argument.Modes.Ref;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}