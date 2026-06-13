namespace MooVC.Syntax.Project.SdkTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenSdkIsUnspecified()
    {
        // Act
        var subject = new Sdk();

        // Assert
        _ = await Assert.That(subject.MinimumVersion).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Name).IsEqualTo(Qualifier.Unqualified);
        _ = await Assert.That(subject.Version).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.IsUnspecified).IsTrue();
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
        _ = await Assert.That(subject.MinimumVersion).IsEqualTo(Snippet.From(SdkTestsData.DefaultMinimumVersion));
        _ = await Assert.That(subject.Name).IsEqualTo(SdkTestsData.DefaultName);
        _ = await Assert.That(subject.Version).IsEqualTo(Snippet.From(SdkTestsData.DefaultVersion));
        _ = await Assert.That(subject.IsUnspecified).IsFalse();
    }
}