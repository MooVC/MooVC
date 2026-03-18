namespace MooVC.Syntax.Attributes.Solution.FileTests;

public sealed class WhenEqualityOperatorFileFileIsCalled
{
    [Test]
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

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new File(FileTestsData.DefaultPath);
        var right = new File(FileTestsData.DefaultPath);

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new File(FileTestsData.DefaultPath);
        var right = new File("assets/other.cs");

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}