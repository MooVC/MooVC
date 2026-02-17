namespace MooVC.Syntax.Attributes.Project.PropertyTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenPropertyIsUndefined()
    {
        // Act
        var subject = new Property();

        // Assert
        subject.Condition.ShouldBe(Snippet.Empty);
        subject.Name.ShouldBe(Name.Unnamed);
        subject.Value.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Property
        {
            Condition = Snippet.From(PropertyTestsData.DefaultCondition),
            Name = PropertyTestsData.DefaultName,
            Value = Snippet.From(PropertyTestsData.DefaultValue),
        };

        // Assert
        subject.Condition.ShouldBe(Snippet.From(PropertyTestsData.DefaultCondition));
        subject.Name.ShouldBe(new Name(PropertyTestsData.DefaultName));
        subject.Value.ShouldBe(Snippet.From(PropertyTestsData.DefaultValue));
        subject.IsUndefined.ShouldBeFalse();
    }
}