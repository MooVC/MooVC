namespace MooVC.Syntax.Attributes.Solution.ItemTests;

using MooVC.Syntax;
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
            Id = Snippet.From(ItemTestsData.DefaultId),
            Name = Snippet.From(ItemTestsData.DefaultName),
            Path = Snippet.From(ItemTestsData.DefaultPath),
            Type = Snippet.From(ItemTestsData.DefaultType),
            Items = [child],
        };

        // Assert
        subject.Id.ShouldBe(Snippet.From(ItemTestsData.DefaultId));
        subject.Name.ShouldBe(Snippet.From(ItemTestsData.DefaultName));
        subject.Path.ShouldBe(Snippet.From(ItemTestsData.DefaultPath));
        subject.Type.ShouldBe(Snippet.From(ItemTestsData.DefaultType));
        subject.Items.ShouldBe(new[] { child });
        subject.IsUndefined.ShouldBeFalse();
    }
}