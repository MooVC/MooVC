namespace MooVC.Syntax.Attributes.Project.ItemGroupTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorItemGroupItemGroupIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        ItemGroup? left = default;
        ItemGroup? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        ItemGroup left = ItemGroupTestsData.Create();
        ItemGroup right = ItemGroupTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        ItemGroup left = ItemGroupTestsData.Create();
        ItemGroup right = ItemGroupTestsData.Create(label: Snippet.From("Other"));

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}