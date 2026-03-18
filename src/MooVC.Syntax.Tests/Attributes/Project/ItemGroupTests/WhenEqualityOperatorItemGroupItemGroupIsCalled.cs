namespace MooVC.Syntax.Attributes.Project.ItemGroupTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorItemGroupItemGroupIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
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