namespace MooVC.Syntax.PathTests;

public sealed class WhenChangeExtensionIsCalled
{
    [Test]
    public async Task GivenExtensionThenReturnsUpdatedPath()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);

        // Act
        Path result = subject.ChangeExtension(PathTestsData.ChangedExtension);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(subject);
        _ = await Assert.That(result.ToString()).IsEqualTo(PathTestsData.DefaultChangedExtensionPath);
    }
}