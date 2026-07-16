namespace MooVC.Syntax.CSharp.ArgumentTests.OptionsTests.FormattersTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        Argument.Options.Formatters first = Argument.Options.Formatters.Call;
        Argument.Options.Formatters second = Argument.Options.Formatters.Declaration;

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
        Argument.Options.Formatters first = Argument.Options.Formatters.Declaration;
        Argument.Options.Formatters second = Argument.Options.Formatters.Declaration;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}