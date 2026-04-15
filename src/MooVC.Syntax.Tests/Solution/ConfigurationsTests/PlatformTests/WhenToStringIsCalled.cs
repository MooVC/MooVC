namespace MooVC.Syntax.Solution.ConfigurationsTests.PlatformTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenSpecifiedPlatformThenReturnsXmlFragment()
    {
        // Arrange
        Configurations.Platform subject = Configurations.Platform.AnyCPU;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo("<Platform Name=\"Any CPU\" />");
    }

    [Test]
    public async Task GivenUnspecifiedPlatformThenReturnsEmptyString()
    {
        // Arrange
        Configurations.Platform subject = Configurations.Platform.Unspecified;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }
}