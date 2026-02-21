namespace MooVC.Syntax.Attributes.Solution.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenItemIsUndefined()
    {
        // Act
        var subject = new Item();

        // Assert
        subject.Id.ShouldBe(Snippet.Empty);
        subject.Items.ShouldBeEmpty();
        subject.Name.ShouldBe(Snippet.Empty);
        subject.Path.ShouldBe(Snippet.Empty);
        subject.Type.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Item child = ItemTestsData.CreateChild();

        // Act
        var subject = new Item
        {
            Id = ItemTestsData.DefaultId,
            Name = ItemTestsData.DefaultName,
            Path = ItemTestsData.DefaultPath,
            Type = ItemTestsData.DefaultType,
            Items = [child],
        };

        // Assert
        subject.Id.ShouldBe(ItemTestsData.DefaultId);
        subject.Name.ShouldBe(ItemTestsData.DefaultName);
        subject.Path.ShouldBe(ItemTestsData.DefaultPath);
        subject.Type.ShouldBe(ItemTestsData.DefaultType);
        subject.Items.ShouldBe(new[] { child });
        subject.IsUndefined.ShouldBeFalse();
    }
}