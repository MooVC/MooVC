namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenConfigurationsAreDefault()
    {
        // Act
        var subject = new Configurations();

        // Assert
        subject.Builds.ShouldBe([Configurations.BuildType.Debug, Configurations.BuildType.Release]);
        subject.Platforms.ShouldBe([Configurations.Platform.AnyCPU]);
        subject.IsDefault.ShouldBeTrue();
    }
}