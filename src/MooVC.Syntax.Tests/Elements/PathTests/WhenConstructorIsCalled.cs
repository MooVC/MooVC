namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenNullThenPathIsEmpty()
    {
        // Arrange
        string? value = default;

        // Act
        var subject = new Path(value);

        // Assert
        subject.IsEmpty.ShouldBeTrue();
        subject.ToString().ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValueThenPathIsNotEmpty()
    {
        // Arrange
        string value = PathTestsData.DefaultPath;

        // Act
        var subject = new Path(value);

        // Assert
        subject.IsEmpty.ShouldBeFalse();
        subject.ToString().ShouldBe(value);
    }
}