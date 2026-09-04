namespace MooVC.Syntax.Resource.ItemTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenResourceIsUndefined()
    {
        // Act
        var subject = new Item();

        // Assert
        _ = await Assert.That(subject.CustomToolNamespace).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Designer).IsEqualTo(Path.Empty);
        _ = await Assert.That(subject.Location).IsEqualTo(Path.Empty);
        _ = await Assert.That(subject.Visibility).IsEqualTo(Item.Scope.Internal);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var customToolNamespace = Snippet.From(ItemTestsData.DefaultCustomToolNamespace);
        var designer = new Path(ItemTestsData.DefaultDesignerPath);
        var location = new Path(ItemTestsData.DefaultLocationPath);

        // Act
        var subject = new Item
        {
            CustomToolNamespace = customToolNamespace,
            Designer = designer,
            Location = location,
            Visibility = Item.Scope.Public,
        };

        // Assert
        _ = await Assert.That(subject.CustomToolNamespace).IsEqualTo(customToolNamespace);
        _ = await Assert.That(subject.Designer).IsEqualTo(designer);
        _ = await Assert.That(subject.Location).IsEqualTo(location);
        _ = await Assert.That(subject.Visibility).IsEqualTo(Item.Scope.Public);
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}