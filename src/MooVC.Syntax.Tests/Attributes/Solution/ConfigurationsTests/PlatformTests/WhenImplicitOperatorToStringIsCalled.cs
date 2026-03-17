namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.PlatformTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public void GivenValueThenReturnsValue()
    {
        // Arrange
        var subject = new Configurations.Platform("CustomPlatform");

        // Act
        string result = subject;

        // Assert
        result.ShouldBe("CustomPlatform");
    }
}