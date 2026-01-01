namespace MooVC.Syntax.Elements.PathTests;

using SystemPath = System.IO.Path;

public sealed class WhenFileNameIsCalled
{
    [Fact]
    public void GivenPathThenReturnsFileName()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        string expected = SystemPath.GetFileName(PathTestsData.DefaultPath);

        // Act
        string result = subject.FileName;

        // Assert
        result.ShouldBe(expected);
    }
}