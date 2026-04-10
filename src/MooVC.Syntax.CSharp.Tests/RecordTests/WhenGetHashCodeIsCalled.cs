namespace MooVC.Syntax.CSharp.RecordTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Record left = RecordTestsData.Create(scope: Scopes.Internal);
        Record right = RecordTestsData.Create(scope: Scopes.Private);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsNotEqualTo(rightHash);
    }

    [Test]
    public async Task GivenEqualValuesThenHashesMatch()
    {
        // Arrange
        Record left = RecordTestsData.Create(extensibility: Extensibility.Implicit);
        Record right = RecordTestsData.Create(extensibility: Extensibility.Implicit);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsEqualTo(rightHash);
    }
}