namespace MooVC.Syntax.CSharp.Attributes.Project.ItemGroupTests;

public sealed class WhenInequalityOperatorItemGroupItemGroupIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        ItemGroup left = ItemGroupTestsData.Create();
        ItemGroup right = ItemGroupTestsData.Create(label: Snippet.From("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}