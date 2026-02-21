namespace MooVC.Syntax.Attributes.Project.OutputTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenTaskOutputIsUndefined()
    {
        // Act
        var subject = new Output();

        // Assert
        subject.Condition.ShouldBe(Snippet.Empty);
        subject.ItemName.ShouldBe(Name.Unnamed);
        subject.PropertyName.ShouldBe(Name.Unnamed);
        subject.TaskParameter.ShouldBe(Name.Unnamed);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Output
        {
            Condition = OutputTestsData.DefaultCondition,
            ItemName = OutputTestsData.DefaultItemName,
            PropertyName = OutputTestsData.DefaultPropertyName,
            TaskParameter = OutputTestsData.DefaultTaskParameter,
        };

        // Assert
        subject.Condition.ShouldBe(OutputTestsData.DefaultCondition);
        subject.ItemName.ShouldBe(OutputTestsData.DefaultItemName);
        subject.PropertyName.ShouldBe(OutputTestsData.DefaultPropertyName);
        subject.TaskParameter.ShouldBe(OutputTestsData.DefaultTaskParameter);
        subject.IsUndefined.ShouldBeFalse();
    }
}