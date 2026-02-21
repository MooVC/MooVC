namespace MooVC.Syntax.Concepts.ResourceTests;

using MooVC.Syntax.Attributes.Resource;
using Resource = MooVC.Syntax.Concepts.Resource;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenResourceIsUndefined()
    {
        // Act
        var subject = new Resource();

        // Assert
        subject.Assemblies.ShouldBeEmpty();
        subject.Data.ShouldBeEmpty();
        subject.Headers.ShouldBeEmpty();
        subject.Metadata.ShouldBeEmpty();
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
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
        subject.Assemblies.ShouldBe(new[] { assembly });
        subject.Data.ShouldBe(new[] { data });
        subject.Headers.ShouldBe(new[] { header });
        subject.Metadata.ShouldBe(new[] { metadata });
        subject.IsUndefined.ShouldBeFalse();
    }
}