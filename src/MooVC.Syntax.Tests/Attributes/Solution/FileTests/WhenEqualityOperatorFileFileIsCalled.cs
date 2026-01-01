namespace MooVC.Syntax.Attributes.Solution.FileTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorFileFileIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        File? left = default;
        File? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        File left = FileTestsData.Create();
        File right = FileTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        File left = FileTestsData.Create();
        File right = FileTestsData.Create(name: Snippet.From("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}