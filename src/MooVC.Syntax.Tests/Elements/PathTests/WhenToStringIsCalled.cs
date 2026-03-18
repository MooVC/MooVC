namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenEmptyThenReturnsEmpty()
    {
        // Arrange
        var subject = new Path(string.Empty);

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValueThenReturnsValue()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).IsEqualTo(PathTestsData.DefaultPath);
    }
}