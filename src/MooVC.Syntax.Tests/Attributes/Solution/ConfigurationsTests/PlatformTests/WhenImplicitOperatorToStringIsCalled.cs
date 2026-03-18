namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.PlatformTests;

using MooVC.Syntax.Attributes.Solution;

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
        await Assert.That(result).IsEqualTo("CustomPlatform");
    }
}