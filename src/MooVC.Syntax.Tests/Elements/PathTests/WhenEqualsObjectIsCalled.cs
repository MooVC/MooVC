namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);

        // Act
        bool result = subject.Equals(default(object));

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        object other = new();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        var other = new Path(PathTestsData.DefaultPath);

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);
        var other = new Path(PathTestsData.DefaultAlternativePath);

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}