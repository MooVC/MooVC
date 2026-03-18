namespace MooVC.Syntax.Elements.PathTests;

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
        await Assert.That(ReferenceEquals(result, subject)).IsFalse();
        await Assert.That(result.ToString()).IsEqualTo(PathTestsData.DefaultChangedExtensionPath);
    }
}