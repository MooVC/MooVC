namespace MooVC.Syntax.CSharp.BinaryTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEquivalentValuesThenHashesMatch()
    {
        // Arrange
        Binary first = BinaryTestsData.Create();
        Binary second = BinaryTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Binary first = BinaryTestsData.Create();
        Binary second = BinaryTestsData.Create(@operator: Binary.Type.Multiply);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }
}