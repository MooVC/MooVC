namespace MooVC.Syntax.CSharp.Attributes.Project.ItemGroupTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenHashCodesMatch()
    {
        // Arrange
        ItemGroup left = ItemGroupTestsData.Create();
        ItemGroup right = ItemGroupTestsData.Create();

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
        ItemGroup left = ItemGroupTestsData.Create();
        ItemGroup right = ItemGroupTestsData.Create(label: Snippet.From("Other"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}