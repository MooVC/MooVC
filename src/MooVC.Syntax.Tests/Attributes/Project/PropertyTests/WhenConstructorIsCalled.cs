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
            Condition = PropertyTestsData.DefaultCondition,
            Name = PropertyTestsData.DefaultName,
            Value = PropertyTestsData.DefaultValue,
        };

        // Assert
        subject.Condition.ShouldBe(PropertyTestsData.DefaultCondition);
        subject.Name.ShouldBe(PropertyTestsData.DefaultName);
        subject.Value.ShouldBe(PropertyTestsData.DefaultValue);
        subject.IsUndefined.ShouldBeFalse();
    }
}