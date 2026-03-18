namespace MooVC.Syntax.Attributes.Project.SdkTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenSdkIsUnspecified()
    {
        // Act
        var subject = new Sdk();

        // Assert
        await Assert.That(subject.MinimumVersion).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Name).IsEqualTo(Qualifier.Unqualified);
        await Assert.That(subject.Version).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.IsUnspecified).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Sdk
        {
            MinimumVersion = Snippet.From(SdkTestsData.DefaultMinimumVersion),
            Name = SdkTestsData.DefaultName,
            Version = Snippet.From(SdkTestsData.DefaultVersion),
        };

        // Assert
        await Assert.That(subject.MinimumVersion).IsEqualTo(Snippet.From(SdkTestsData.DefaultMinimumVersion));
        await Assert.That(subject.Name).IsEqualTo(SdkTestsData.DefaultName);
        await Assert.That(subject.Version).IsEqualTo(Snippet.From(SdkTestsData.DefaultVersion));
        await Assert.That(subject.IsUnspecified).IsFalse();
    }
}