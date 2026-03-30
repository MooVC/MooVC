namespace MooVC.Syntax.CSharp.BinaryTests.TypeTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        Binary.Type first = Binary.Type.Add;
        Binary.Type second = Binary.Type.Subtract;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenEquivalentValuesThenReturnsTheSameHash()
    {
        // Arrange
        Binary.Type first = Binary.Type.Add;
        Binary.Type second = Binary.Type.Add;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}