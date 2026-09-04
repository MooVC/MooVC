namespace MooVC.Syntax.CSharp.StructTests.KindsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        Struct.Kinds left = Struct.Kinds.Record;
        Struct.Kinds right = Struct.Kinds.Ref;

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
        Struct.Kinds left = Struct.Kinds.Record;
        Struct.Kinds right = Struct.Kinds.Record;

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(rightHash).IsEqualTo(leftHash);
    }
}