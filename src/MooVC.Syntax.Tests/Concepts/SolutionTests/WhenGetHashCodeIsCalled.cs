namespace MooVC.Syntax.Concepts.SolutionTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public void GivenEqualValuesThenHashCodesMatch()
    {
        // Arrange
        Solution left = SolutionTestsData.Create();
        Solution right = SolutionTestsData.Create();

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldBe(rightHash);
    }

    [Test]
    public void GivenDifferentValuesThenHashCodesDiffer()
    {
        // Arrange
        Solution left = SolutionTestsData.Create();
        Solution right = SolutionTestsData.Create(folder: new Folder { Name = "Other" });

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}