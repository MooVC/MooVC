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
            Condition = Snippet.From(OutputTestsData.DefaultCondition),
            ItemName = OutputTestsData.DefaultItemName,
            PropertyName = OutputTestsData.DefaultPropertyName,
            TaskParameter = OutputTestsData.DefaultTaskParameter,
        };

        // Assert
        subject.Condition.ShouldBe(Snippet.From(OutputTestsData.DefaultCondition));
        subject.ItemName.ShouldBe(new Name(OutputTestsData.DefaultItemName));
        subject.PropertyName.ShouldBe(new Name(OutputTestsData.DefaultPropertyName));
        subject.TaskParameter.ShouldBe(new Name(OutputTestsData.DefaultTaskParameter));
        subject.IsUndefined.ShouldBeFalse();
    }
}