namespace MooVC.Syntax.ObjectExtensionsTests;

public sealed class WhenApplyIsCalled
{
    private const string Original = "Original";
    private const string Updated = "Updated";

    [Test]
    public async Task GivenActionThenReturnsActionResult()
    {
        // Arrange
        const string subject = Original;

        // Act
        string result = subject.Apply(_ => Updated);

        // Assert
        _ = await Assert.That(result).IsEqualTo(Updated);
    }

    [Test]
    public async Task GivenNoActionThenReturnsSource()
    {
        // Arrange
        const string subject = Original;
        Func<string, string>? action = default;

        // Act
        string result = subject.Apply(action!);

        // Assert
        _ = await Assert.That(result).IsEqualTo(subject);
    }
}