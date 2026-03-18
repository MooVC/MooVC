namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

public sealed class WhenGetHashCodeIsCalled
{
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

    [Test]
    public async Task GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Record left = RecordTestsData.Create(scope: Scope.Internal);
        Record right = RecordTestsData.Create(scope: Scope.Private);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsNotEqualTo(rightHash);
    }
}