namespace MooVC.Syntax.Solution.ConfigurationsTests.PlatformTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsValue()
    {
        // Arrange
        var subject = new Configurations.Platform("CustomPlatform");

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo("CustomPlatform");
    }
}