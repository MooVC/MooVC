namespace MooVC.Syntax.Elements.PathTests;

using SystemPath = System.IO.Path;

public sealed class WhenDirectoryNameIsCalled
{
    [Fact]
    public void GivenPathThenReturnsDirectoryName()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        string? expected = SystemPath.GetDirectoryName(PathTestsData.DefaultPath);

        // Act
        string result = subject.DirectoryName;

        // Assert
        result.ShouldBe(expected);
    }
}