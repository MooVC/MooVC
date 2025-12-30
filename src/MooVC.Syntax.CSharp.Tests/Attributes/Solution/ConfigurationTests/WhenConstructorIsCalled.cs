namespace MooVC.Syntax.CSharp.Attributes.Solution.ConfigurationTests;

using MooVC.Syntax.CSharp;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenConfigurationIsUndefined()
    {
        // Act
        var subject = new Configuration();

        // Assert
        subject.Name.ShouldBe(Snippet.Empty);
        subject.Platform.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Configuration
        {
            Name = Snippet.From(ConfigurationTestsData.DefaultName),
            Platform = Snippet.From(ConfigurationTestsData.DefaultPlatform),
        };

        // Assert
        subject.Name.ShouldBe(Snippet.From(ConfigurationTestsData.DefaultName));
        subject.Platform.ShouldBe(Snippet.From(ConfigurationTestsData.DefaultPlatform));
        subject.IsUndefined.ShouldBeFalse();
    }
}