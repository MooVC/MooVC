namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenEmptyThenReturnsEmpty()
    {
        // Arrange
        var subject = new Path(string.Empty);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValueThenReturnsValue()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(PathTestsData.DefaultPath);
    }
}