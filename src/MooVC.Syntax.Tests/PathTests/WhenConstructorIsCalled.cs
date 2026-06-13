namespace MooVC.Syntax.PathTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenNullThenPathIsEmpty()
    {
        // Arrange
        string? value = default;

        // Act
        var subject = new Path(value);

        // Assert
        _ = await Assert.That(subject.IsEmpty).IsTrue();
        _ = await Assert.That(subject.ToString()).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValueThenPathIsNotEmpty()
    {
        // Arrange
        string value = PathTestsData.DefaultPath;

        // Act
        var subject = new Path(value);

        // Assert
        _ = await Assert.That(subject.IsEmpty).IsFalse();
        _ = await Assert.That(subject.ToString()).IsEqualTo(value);
    }
}