namespace MooVC.Syntax.CSharp.InterfaceTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Interface left = InterfaceTestsData.Create(isPartial: true);
        Interface right = InterfaceTestsData.Create(isPartial: false);

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
        Interface left = InterfaceTestsData.Create(scope: Scope.Internal);
        Interface right = InterfaceTestsData.Create(scope: Scope.Internal);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsEqualTo(rightHash);
    }
}