namespace MooVC.Syntax.Attributes.Project.MetadataTests;

using MooVC.Syntax.Elements;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
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

    [Test]
    public void GivenDifferentValuesThenHashCodesDiffer()
    {
        // Arrange
        Metadata left = MetadataTestsData.Create();
        Metadata right = MetadataTestsData.Create(name: new Name("Other"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}