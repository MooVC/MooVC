namespace MooVC.Syntax.Attributes.Project.SdkTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenSdkIsUnspecified()
    {
        // Act
        var subject = new Sdk();

        // Assert
        subject.MinimumVersion.ShouldBe(Snippet.Empty);
        subject.Name.ShouldBe(Qualifier.Unqualified);
        subject.Version.ShouldBe(Snippet.Empty);
        subject.IsUnspecified.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Sdk
        {
            MinimumVersion = Snippet.From(SdkTestsData.DefaultMinimumVersion),
            Name = SdkTestsData.DefaultName,
            Version = Snippet.From(SdkTestsData.DefaultVersion),
        };

        // Assert
        subject.MinimumVersion.ShouldBe(Snippet.From(SdkTestsData.DefaultMinimumVersion));
        subject.Name.ShouldBe(SdkTestsData.DefaultName);
        subject.Version.ShouldBe(Snippet.From(SdkTestsData.DefaultVersion));
        subject.IsUnspecified.ShouldBeFalse();
    }
}