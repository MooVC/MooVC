namespace MooVC.Syntax.CSharp.ClassTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Class left = ClassTestsData.Create(scope: Scopes.Internal);
        Class right = ClassTestsData.Create(scope: Scopes.Private);

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
        Class left = ClassTestsData.Create(extensibility: Modifiers.Implicit);
        Class right = ClassTestsData.Create(extensibility: Modifiers.Implicit);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsEqualTo(rightHash);
    }
}