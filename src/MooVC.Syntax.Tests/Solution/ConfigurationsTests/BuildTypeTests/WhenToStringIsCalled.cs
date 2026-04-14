namespace MooVC.Syntax.Solution.ConfigurationsTests.BuildTypeTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenNamedBuildTypeThenReturnsXmlFragment()
    {
        // Arrange
        Configurations.BuildType subject = Configurations.BuildType.Debug;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo("<BuildType Name=\"Debug\" />");
    }

    [Test]
    public async Task GivenUnnamedBuildTypeThenReturnsEmptyString()
    {
        // Arrange
        Configurations.BuildType subject = Configurations.BuildType.Unnamed;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }
}
