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
        _ = await Assert.That(subject.Builds).IsEquivalentTo([Configurations.BuildType.Debug, Configurations.BuildType.Release]);
        _ = await Assert.That(subject.Platforms).IsEquivalentTo([Configurations.Platform.AnyCPU]);
        _ = await Assert.That(subject.IsDefault).IsTrue();
    }
}