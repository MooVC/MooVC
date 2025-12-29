namespace MooVC.Syntax.CSharp.Attributes.Project.ItemGroupTests;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenItemGroupIsUndefined()
    {
        // Act
        var subject = new ItemGroup();

        // Assert
        subject.Condition.ShouldBe(Snippet.Empty);
        subject.Label.ShouldBe(Snippet.Empty);
        subject.Items.ShouldBeEmpty();
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Item item = ItemGroupTestsData.CreateItem();

        // Act
        var subject = new ItemGroup
        {
            Condition = Snippet.From(ItemGroupTestsData.DefaultCondition),
            Label = Snippet.From(ItemGroupTestsData.DefaultLabel),
            Items = [item],
        };

        // Assert
        subject.Condition.ShouldBe(Snippet.From(ItemGroupTestsData.DefaultCondition));
        subject.Label.ShouldBe(Snippet.From(ItemGroupTestsData.DefaultLabel));
        subject.Items.ShouldBe(new[] { item });
        subject.IsUndefined.ShouldBeFalse();
    }
}