namespace MooVC.Syntax.CSharp.Attributes.Project.PropertyGroupTests;

public sealed class WhenInequalityOperatorPropertyGroupPropertyGroupIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        PropertyGroup left = PropertyGroupTestsData.Create();
        PropertyGroup right = PropertyGroupTestsData.Create(label: Snippet.From("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}