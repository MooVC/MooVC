namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.OptionsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenMatchingValuesThenReturnsSameHash()
    {
        // Arrange
        var first = new Argument.Options();
        var second = new Argument.Options();

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
        var first = new Argument.Options();

        Argument.Options second = new Argument.Options()
            .WithNaming(Variable.Options.Pascal);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }
}