namespace MooVC.Syntax.Attributes.Project.TargetTaskTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenTargetTaskIsUndefined()
    {
        // Act
        var subject = new TargetTask();

        // Assert
        subject.Condition.ShouldBe(Snippet.Empty);
        subject.ContinueOnError.ShouldBe(TargetTask.Options.ErrorAndStop);
        subject.Name.ShouldBe(Identifier.Unnamed);
        subject.Outputs.ShouldBeEmpty();
        subject.Parameters.ShouldBeEmpty();
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Output output = TargetTaskTestsData.CreateOutput();
        Parameter parameter = TargetTaskTestsData.CreateParameter();

        // Act
        var subject = new TargetTask
        {
            Condition = Snippet.From(TargetTaskTestsData.DefaultCondition),
            ContinueOnError = TargetTask.Options.WarnAndContinue,
            Name = new Identifier(TargetTaskTestsData.DefaultName),
            Outputs = [output],
            Parameters = [parameter],
        };

        // Assert
        subject.Condition.ShouldBe(Snippet.From(TargetTaskTestsData.DefaultCondition));
        subject.ContinueOnError.ShouldBe(TargetTask.Options.WarnAndContinue);
        subject.Name.ShouldBe(new Identifier(TargetTaskTestsData.DefaultName));
        subject.Outputs.ShouldBe(new[] { output });
        subject.Parameters.ShouldBe(new[] { parameter });
        subject.IsUndefined.ShouldBeFalse();
    }
}