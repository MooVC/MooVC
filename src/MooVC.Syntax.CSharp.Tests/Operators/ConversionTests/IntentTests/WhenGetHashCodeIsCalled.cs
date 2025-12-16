namespace MooVC.Syntax.CSharp.Operators.ConversionTests.IntentTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenTheSameValueThenReturnsTheSameHash()
    {
        // Arrange
        Conversion.Intent first = Conversion.Intent.From;
        Conversion.Intent second = Conversion.Intent.From;

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
        Conversion.Intent first = Conversion.Intent.From;
        Conversion.Intent second = Conversion.Intent.To;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}
