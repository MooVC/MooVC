namespace MooVC.Syntax.Elements.PathTests;

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
        await Assert.That(subject.IsEmpty).IsTrue();
        await Assert.That(subject.ToString()).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValueThenPathIsNotEmpty()
    {
        // Arrange
        string value = PathTestsData.DefaultPath;

        // Act
        var subject = new Path(value);

        // Assert
        await Assert.That(subject.IsEmpty).IsFalse();
        await Assert.That(subject.ToString()).IsEqualTo(value);
    }
}