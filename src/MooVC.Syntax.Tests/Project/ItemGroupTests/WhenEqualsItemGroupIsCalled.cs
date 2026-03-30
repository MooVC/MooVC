namespace MooVC.Syntax.Project.ItemGroupTests;

public sealed class WhenEqualsItemGroupIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        ItemGroup subject = ItemGroupTestsData.Create();
        ItemGroup other = ItemGroupTestsData.Create(label: Snippet.From("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        ItemGroup subject = ItemGroupTestsData.Create();
        ItemGroup other = ItemGroupTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        ItemGroup subject = ItemGroupTestsData.Create();
        ItemGroup? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}