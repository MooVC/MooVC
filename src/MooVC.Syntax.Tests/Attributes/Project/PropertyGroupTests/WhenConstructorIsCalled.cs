namespace MooVC.Syntax.Attributes.Project.PropertyGroupTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenPropertyGroupIsUndefined()
    {
        // Act
        var subject = new PropertyGroup();

        // Assert
        subject.Condition.ShouldBe(Snippet.Empty);
        subject.Label.ShouldBe(Snippet.Empty);
        subject.Properties.ShouldBeEmpty();
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Property property = PropertyGroupTestsData.CreateProperty();

        // Act
        var subject = new PropertyGroup
        {
            Condition = PropertyGroupTestsData.DefaultCondition,
            Label = PropertyGroupTestsData.DefaultLabel,
            Properties = [property],
        };

        // Assert
        subject.Condition.ShouldBe(PropertyGroupTestsData.DefaultCondition);
        subject.Label.ShouldBe(PropertyGroupTestsData.DefaultLabel);
        subject.Properties.ShouldBe(new[] { property });
        subject.IsUndefined.ShouldBeFalse();
    }
}