namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenConfigurationsAreDefault()
    {
        // Act
        var subject = new Configurations();

        // Assert
        await Assert.That(subject.Builds).IsEqualTo([Configurations.BuildType.Debug, Configurations.BuildType.Release]);
        await Assert.That(subject.Platforms).IsEqualTo([Configurations.Platform.AnyCPU]);
        await Assert.That(subject.IsDefault).IsTrue();
    }
}