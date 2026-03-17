namespace MooVC.Syntax.Attributes.Solution.FileTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public void GivenNullThenInstanceIsCreated()
    {
        // Arrange
        string? value = default;

        // Act & Assert
        _ = Should.NotThrow(() => _ = new File(value));
    }

    [Test]
    public void GivenEmptyThenFileIsUndefined()
    {
        // Arrange
        string value = string.Empty;

        // Act
        var subject = new File(value);

        // Assert
        subject.IsUndefined.ShouldBeTrue();
        subject.ToString().ShouldBe(string.Empty);
    }

    [Test]
    public void GivenValueThenFileIsNotUndefined()
    {
        // Arrange
        string value = FileTestsData.DefaultPath;

        // Act
        var subject = new File(value);

        // Assert
        subject.IsUndefined.ShouldBeFalse();
        subject.ToFragments().ShouldNotBeEmpty();
    }
}