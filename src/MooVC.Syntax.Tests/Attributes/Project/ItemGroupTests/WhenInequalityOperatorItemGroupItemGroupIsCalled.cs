namespace MooVC.Syntax.Attributes.Project.ItemGroupTests;

using MooVC.Syntax.Elements;

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