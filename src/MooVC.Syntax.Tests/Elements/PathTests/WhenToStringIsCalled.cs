namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public void GivenEmptyThenReturnsEmpty()
    {
        // Arrange
        var subject = new Path(string.Empty);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Test]
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