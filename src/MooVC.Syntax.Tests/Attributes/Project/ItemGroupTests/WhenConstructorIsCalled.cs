namespace MooVC.Syntax.Attributes.Project.ItemGroupTests;

using MooVC.Syntax.Elements;

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
            Condition = ItemGroupTestsData.DefaultCondition,
            Label = ItemGroupTestsData.DefaultLabel,
            Items = [item],
        };

        // Assert
        subject.Condition.ShouldBe(ItemGroupTestsData.DefaultCondition);
        subject.Label.ShouldBe(ItemGroupTestsData.DefaultLabel);
        subject.Items.ShouldBe(new[] { item });
        subject.IsUndefined.ShouldBeFalse();
    }
}