namespace MooVC.Syntax.Concepts.ResourceTests;

using MooVC.Syntax.Attributes.Resource;
using Resource = MooVC.Syntax.Concepts.Resource;

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
        _ = await Assert.That(subject.Assemblies).IsEqualTo(new[] { assembly });
        _ = await Assert.That(subject.Data).IsEqualTo(new[] { data });
        _ = await Assert.That(subject.Headers).IsEqualTo(new[] { header });
        _ = await Assert.That(subject.Metadata).IsEqualTo(new[] { metadata });
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}