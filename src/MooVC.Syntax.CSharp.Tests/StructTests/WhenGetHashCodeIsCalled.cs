namespace MooVC.Syntax.CSharp.StructTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        Struct left = StructTestsData.Create(behavior: Struct.Kinds.ReadOnly);
        Struct right = StructTestsData.Create(behavior: Struct.Kinds.Record);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(rightHash).IsNotEqualTo(leftHash);
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsSameHash()
    {
        // Arrange
        Struct left = StructTestsData.Create(scope: Scopes.Internal);
        Struct right = StructTestsData.Create(scope: Scopes.Internal);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(rightHash).IsEqualTo(leftHash);
    }
}