namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenResourceIsUndefined()
    {
        // Act
        var subject = new Resource();

        // Assert
        subject.CustomToolNamespace.ShouldBe(Snippet.Empty);
        subject.Designer.ShouldBe(Path.Empty);
        subject.Location.ShouldBe(Path.Empty);
        subject.Visibility.ShouldBe(Resource.Scope.Internal);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var customToolNamespace = ResourceTestsData.DefaultCustomToolNamespace;
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
        subject.CustomToolNamespace.ShouldBe(customToolNamespace);
        subject.Designer.ShouldBe(designer);
        subject.Location.ShouldBe(location);
        subject.Visibility.ShouldBe(Resource.Scope.Public);
        subject.IsUndefined.ShouldBeFalse();
    }
}