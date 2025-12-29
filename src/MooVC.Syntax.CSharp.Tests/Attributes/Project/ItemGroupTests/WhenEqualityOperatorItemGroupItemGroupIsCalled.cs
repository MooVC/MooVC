namespace MooVC.Syntax.CSharp.Attributes.Project.ItemGroupTests;

public sealed class WhenEqualityOperatorItemGroupItemGroupIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        ItemGroup? left = default;
        ItemGroup? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        ItemGroup left = ItemGroupTestsData.Create();
        ItemGroup right = ItemGroupTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        ItemGroup left = ItemGroupTestsData.Create();
        ItemGroup right = ItemGroupTestsData.Create(label: Snippet.From("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}