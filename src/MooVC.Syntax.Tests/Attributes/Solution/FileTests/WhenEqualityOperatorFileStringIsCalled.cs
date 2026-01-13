namespace MooVC.Syntax.Attributes.Solution.FileTests;

public sealed class WhenEqualityOperatorFileStringIsCalled
{
    [Fact]
    public void GivenSameValueThenReturnsTrue()
    {
        // Arrange
        var left = new File(FileTestsData.DefaultPath);
        string right = FileTestsData.DefaultPath;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        var left = new File(FileTestsData.DefaultPath);
        const string right = "assets/other.cs";

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}