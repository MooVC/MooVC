namespace MooVC.Compression.Configuration.TypeTests;

public sealed class WhenEqualsIsCalled
{
    [Test]
    [Arguments("GZip", "GZip", true)]
    [Arguments("GZip", "gzip", false)]
    [Arguments("GZip", "Deflate", false)]
    public async Task GivenIdentifiersThenEqualityIsOrdinal(string firstValue, string secondValue, bool expected)
    {
        // Arrange
        Type first = firstValue;
        Type second = secondValue;

        // Act
        bool result = first.Equals(second);

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
        _ = await Assert.That(first == second).IsEqualTo(expected);
        _ = await Assert.That(first != second).IsEqualTo(!expected);
    }

    [Test]
    public async Task GivenEqualIdentifiersThenHashesMatch()
    {
        // Arrange
        Type first = "GZip";
        Type second = "GZip";

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}