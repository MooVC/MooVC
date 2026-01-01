namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenChangeExtensionIsCalled
{
    [Fact]
    public void GivenExtensionThenReturnsUpdatedPath()
    {
        // Arrange
        var subject = new Path(PathTestsData.DefaultPath);

        // Act
        Path result = subject.ChangeExtension(PathTestsData.ChangedExtension);

        // Assert
        result.ShouldNotBeSameAs(subject);
        result.ToString().ShouldBe(PathTestsData.DefaultChangedExtensionPath);
    }
}