namespace MooVC.Syntax.CSharp.Attributes.Project.ImportTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenHashCodesMatch()
    {
        // Arrange
        Import left = ImportTestsData.Create();
        Import right = ImportTestsData.Create();

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldBe(rightHash);
    }

    [Fact]
    public void GivenDifferentValuesThenHashCodesDiffer()
    {
        // Arrange
        Import left = ImportTestsData.Create();
        Import right = ImportTestsData.Create(label: Snippet.From("Other"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}