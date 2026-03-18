namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEquivalentConversionsThenReturnTheSameValue()
    {
        // Arrange
        Conversion first = ConversionTestsData.Create();
        Conversion second = ConversionTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(secondHash).IsEqualTo(firstHash);
    }
}