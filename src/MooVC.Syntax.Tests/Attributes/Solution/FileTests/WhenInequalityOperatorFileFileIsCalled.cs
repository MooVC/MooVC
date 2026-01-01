namespace MooVC.Syntax.Attributes.Solution.FileTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorFileFileIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        File? left = default;
        File? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        File left = FileTestsData.Create();
        File right = FileTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        File left = FileTestsData.Create();
        File right = FileTestsData.Create(id: Snippet.From("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}