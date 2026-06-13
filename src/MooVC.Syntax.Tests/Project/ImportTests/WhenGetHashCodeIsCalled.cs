namespace MooVC.Syntax.Project.ImportTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenHashCodesDiffer()
    {
        // Arrange
        Import left = ImportTestsData.Create();
        Import right = ImportTestsData.Create(label: Snippet.From("Other"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsNotEqualTo(rightHash);
    }

    [Test]
    public async Task GivenEqualValuesThenHashCodesMatch()
    {
        // Arrange
        Import left = ImportTestsData.Create();
        Import right = ImportTestsData.Create();

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsEqualTo(rightHash);
    }
}