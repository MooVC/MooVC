namespace MooVC.Syntax.CSharp.Attributes.Project.PropertyGroupTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenHashCodesMatch()
    {
        // Arrange
        PropertyGroup left = PropertyGroupTestsData.Create();
        PropertyGroup right = PropertyGroupTestsData.Create();

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
        PropertyGroup left = PropertyGroupTestsData.Create();
        PropertyGroup right = PropertyGroupTestsData.Create(label: Snippet.From("Other"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}