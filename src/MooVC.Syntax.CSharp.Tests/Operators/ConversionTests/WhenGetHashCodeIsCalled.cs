namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEquivalentConversionsThenReturnTheSameValue()
    {
        // Arrange
        Conversion first = ConversionTestsData.Create();
        Conversion second = ConversionTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        secondHash.ShouldBe(firstHash);
    }
}