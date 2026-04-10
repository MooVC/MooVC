namespace MooVC.Syntax.CSharp.BinaryTests.TypesTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        Binary.Types first = Binary.Types.Add;
        Binary.Types second = Binary.Types.Subtract;

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
        Binary.Types first = Binary.Types.Add;
        Binary.Types second = Binary.Types.Add;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}