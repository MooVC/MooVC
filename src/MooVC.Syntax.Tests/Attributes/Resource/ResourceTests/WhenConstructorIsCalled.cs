namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenResourceIsUndefined()
    {
        // Act
        var subject = new Resource();

        // Assert
        await Assert.That(subject.CustomToolNamespace).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Designer).IsEqualTo(Path.Empty);
        await Assert.That(subject.Location).IsEqualTo(Path.Empty);
        await Assert.That(subject.Visibility).IsEqualTo(Resource.Scope.Internal);
        await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var customToolNamespace = Snippet.From(ResourceTestsData.DefaultCustomToolNamespace);
        var designer = new Path(ResourceTestsData.DefaultDesignerPath);
        var location = new Path(ResourceTestsData.DefaultLocationPath);

        // Act
        var subject = new Resource
        {
            CustomToolNamespace = customToolNamespace,
            Designer = designer,
            Location = location,
            Visibility = Resource.Scope.Public,
        };

        // Assert
        await Assert.That(subject.CustomToolNamespace).IsEqualTo(customToolNamespace);
        await Assert.That(subject.Designer).IsEqualTo(designer);
        await Assert.That(subject.Location).IsEqualTo(location);
        await Assert.That(subject.Visibility).IsEqualTo(Resource.Scope.Public);
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}