namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.FormatterTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenMatchingValuesThenReturnsSameHash()
    {
        // Arrange
        Argument.Formatter first = Argument.Formatter.Declaration;
        Argument.Formatter second = Argument.Formatter.Declaration;

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
        Argument.Formatter first = Argument.Formatter.Call;
        Argument.Formatter second = Argument.Formatter.Declaration;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}