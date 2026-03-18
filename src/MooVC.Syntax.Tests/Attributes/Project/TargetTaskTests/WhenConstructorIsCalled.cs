namespace MooVC.Syntax.Attributes.Project.TargetTaskTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenTargetTaskIsUndefined()
    {
        // Act
        var subject = new TargetTask();

        // Assert
        await Assert.That(subject.Condition).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.ContinueOnError).IsEqualTo(TargetTask.Options.ErrorAndStop);
        await Assert.That(subject.Name).IsEqualTo(Name.Unnamed);
        await Assert.That(subject.Outputs).IsEmpty();
        await Assert.That(subject.Parameters).IsEmpty();
        await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Output output = TargetTaskTestsData.CreateOutput();
        Parameter parameter = TargetTaskTestsData.CreateParameter();

        // Act
        var subject = new TargetTask
        {
            Condition = Snippet.From(TargetTaskTestsData.DefaultCondition),
            ContinueOnError = TargetTask.Options.WarnAndContinue,
            Name = TargetTaskTestsData.DefaultName,
            Outputs = [output],
            Parameters = [parameter],
        };

        // Assert
        await Assert.That(subject.Condition).IsEqualTo(Snippet.From(TargetTaskTestsData.DefaultCondition));
        await Assert.That(subject.ContinueOnError).IsEqualTo(TargetTask.Options.WarnAndContinue);
        await Assert.That(subject.Name).IsEqualTo(new Name(TargetTaskTestsData.DefaultName));
        await Assert.That(subject.Outputs).IsEqualTo(new[] { output });
        await Assert.That(subject.Parameters).IsEqualTo(new[] { parameter });
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}