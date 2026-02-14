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
        subject.ItemName.ShouldBe(Identifier.Unnamed);
        subject.PropertyName.ShouldBe(Identifier.Unnamed);
        subject.TaskParameter.ShouldBe(Identifier.Unnamed);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Output
        {
            Condition = Snippet.From(OutputTestsData.DefaultCondition),
            ItemName = new Identifier(OutputTestsData.DefaultItemName),
            PropertyName = new Identifier(OutputTestsData.DefaultPropertyName),
            TaskParameter = new Identifier(OutputTestsData.DefaultTaskParameter),
        };

        // Assert
        subject.Condition.ShouldBe(Snippet.From(OutputTestsData.DefaultCondition));
        subject.ItemName.ShouldBe(new Identifier(OutputTestsData.DefaultItemName));
        subject.PropertyName.ShouldBe(new Identifier(OutputTestsData.DefaultPropertyName));
        subject.TaskParameter.ShouldBe(new Identifier(OutputTestsData.DefaultTaskParameter));
        subject.IsUndefined.ShouldBeFalse();
    }
}