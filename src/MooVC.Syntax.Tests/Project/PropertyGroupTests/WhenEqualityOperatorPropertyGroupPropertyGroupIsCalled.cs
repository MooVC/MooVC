namespace MooVC.Syntax.Project.PropertyGroupTests;

public sealed class WhenEqualityOperatorPropertyGroupPropertyGroupIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        PropertyGroup? left = default;
        PropertyGroup? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        PropertyGroup left = PropertyGroupTestsData.Create();
        PropertyGroup right = PropertyGroupTestsData.Create(label: Snippet.From("Other"));

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        PropertyGroup left = PropertyGroupTestsData.Create();
        PropertyGroup right = PropertyGroupTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}