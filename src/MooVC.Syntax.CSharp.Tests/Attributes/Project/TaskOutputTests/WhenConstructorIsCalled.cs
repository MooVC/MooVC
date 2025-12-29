namespace MooVC.Syntax.CSharp.Attributes.Project.TaskOutputTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenTaskOutputIsUndefined()
    {
        // Act
        var subject = new TaskOutput();

        // Assert
        subject.Condition.ShouldBe(Snippet.Empty);
        subject.ItemName.ShouldBe(Identifier.Unnamed);
        subject.PropertyName.ShouldBe(Identifier.Unnamed);
        subject.TaskParameter.ShouldBe(Identifier.Unnamed);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new TaskOutput
        {
            Condition = Snippet.From(TaskOutputTestsData.DefaultCondition),
            ItemName = new Identifier(TaskOutputTestsData.DefaultItemName),
            PropertyName = new Identifier(TaskOutputTestsData.DefaultPropertyName),
            TaskParameter = new Identifier(TaskOutputTestsData.DefaultTaskParameter),
        };

        // Assert
        subject.Condition.ShouldBe(Snippet.From(TaskOutputTestsData.DefaultCondition));
        subject.ItemName.ShouldBe(new Identifier(TaskOutputTestsData.DefaultItemName));
        subject.PropertyName.ShouldBe(new Identifier(TaskOutputTestsData.DefaultPropertyName));
        subject.TaskParameter.ShouldBe(new Identifier(TaskOutputTestsData.DefaultTaskParameter));
        subject.IsUndefined.ShouldBeFalse();
    }
}