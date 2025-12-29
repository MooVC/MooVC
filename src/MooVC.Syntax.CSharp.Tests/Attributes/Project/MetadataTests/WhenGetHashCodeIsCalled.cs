namespace MooVC.Syntax.CSharp.Attributes.Project.MetadataTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenHashCodesMatch()
    {
        // Arrange
        Metadata left = MetadataTestsData.Create();
        Metadata right = MetadataTestsData.Create();

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
        Metadata left = MetadataTestsData.Create();
        Metadata right = MetadataTestsData.Create(name: new Identifier("Other"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}