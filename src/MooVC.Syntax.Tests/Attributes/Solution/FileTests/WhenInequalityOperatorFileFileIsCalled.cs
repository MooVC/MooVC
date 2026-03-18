namespace MooVC.Syntax.Attributes.Solution.FileTests;

public sealed class WhenInequalityOperatorFileFileIsCalled
{
    [Test]
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

    [Test]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new File(FileTestsData.DefaultPath);
        var right = new File(FileTestsData.DefaultPath);

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new File(FileTestsData.DefaultPath);
        var right = new File("assets/other.cs");

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}