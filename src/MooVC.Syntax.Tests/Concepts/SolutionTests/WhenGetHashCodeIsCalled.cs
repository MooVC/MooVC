namespace MooVC.Syntax.Concepts.SolutionTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenHashCodesMatch()
    {
        // Arrange
        Solution left = SolutionTestsData.Create();
        Solution right = SolutionTestsData.Create();

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsEqualTo(rightHash);
    }

    [Test]
    public async Task GivenDifferentValuesThenHashCodesDiffer()
    {
        // Arrange
        Solution left = SolutionTestsData.Create();
        Solution right = SolutionTestsData.Create(folder: new Folder { Name = "Other" });

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsNotEqualTo(rightHash);
    }
}