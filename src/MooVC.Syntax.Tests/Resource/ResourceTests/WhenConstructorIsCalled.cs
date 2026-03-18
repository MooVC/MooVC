namespace MooVC.Syntax.Resource.ResourceTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenResourceIsUndefined()
    {
        // Act
        var subject = new Resource();

        // Assert
        _ = await Assert.That(subject.Assemblies).IsEmpty();
        _ = await Assert.That(subject.Data).IsEmpty();
        _ = await Assert.That(subject.Headers).IsEmpty();
        _ = await Assert.That(subject.Metadata).IsEmpty();
        _ = await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Assembly assembly = ResourceTestsData.CreateAssembly();
        Data data = ResourceTestsData.CreateData();
        Header header = ResourceTestsData.CreateHeader();
        Metadata metadata = ResourceTestsData.CreateMetadata();

        // Act
        var subject = new Resource
        {
            Assemblies = [assembly],
            Data = [data],
            Headers = [header],
            Metadata = [metadata],
        };

        // Assert
        _ = await Assert.That(subject.Assemblies).IsEquivalentTo([assembly]);
        _ = await Assert.That(subject.Data).IsEquivalentTo([data]);
        _ = await Assert.That(subject.Headers).IsEquivalentTo([header]);
        _ = await Assert.That(subject.Metadata).IsEquivalentTo([metadata]);
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}