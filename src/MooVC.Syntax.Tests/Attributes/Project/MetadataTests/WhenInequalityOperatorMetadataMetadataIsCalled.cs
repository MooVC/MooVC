namespace MooVC.Syntax.Attributes.Project.MetadataTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorMetadataMetadataIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Metadata left = MetadataTestsData.Create();
        Metadata right = MetadataTestsData.Create(name: "Other");

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}