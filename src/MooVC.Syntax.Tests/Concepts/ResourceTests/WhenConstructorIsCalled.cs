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
        await Assert.That(subject.Assemblies).IsEmpty();
        await Assert.That(subject.Data).IsEmpty();
        await Assert.That(subject.Headers).IsEmpty();
        await Assert.That(subject.Metadata).IsEmpty();
        await Assert.That(subject.IsUndefined).IsTrue();
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
        await Assert.That(subject.Assemblies).IsEqualTo(new[] { assembly });
        await Assert.That(subject.Data).IsEqualTo(new[] { data });
        await Assert.That(subject.Headers).IsEqualTo(new[] { header });
        await Assert.That(subject.Metadata).IsEqualTo(new[] { metadata });
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}