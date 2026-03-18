namespace MooVC.Syntax.Attributes.Solution.FileTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenNullThenInstanceIsCreated()
    {
        // Arrange
        string? value = default;

        // Act & Assert
        _ = await Assert.That(() => _ = new File(value)).ThrowsNothing();
    }

    [Test]
    public async Task GivenEmptyThenFileIsUndefined()
    {
        // Arrange
        string value = string.Empty;

        // Act
        var subject = new File(value);

        // Assert
        await Assert.That(subject.IsUndefined).IsTrue();
        await Assert.That(subject.ToString()).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValueThenFileIsNotUndefined()
    {
        // Arrange
        string value = FileTestsData.DefaultPath;

        // Act
        var subject = new File(value);

        // Assert
        await Assert.That(subject.IsUndefined).IsFalse();
        await Assert.That(subject.ToFragments()).IsNotEmpty();
    }
}