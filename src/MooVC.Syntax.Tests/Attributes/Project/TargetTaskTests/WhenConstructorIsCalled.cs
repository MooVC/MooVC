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
        _ = await Assert.That(subject.Condition).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.ContinueOnError).IsEqualTo(TargetTask.Options.ErrorAndStop);
        _ = await Assert.That(subject.Name).IsEqualTo(Name.Unnamed);
        _ = await Assert.That(subject.Outputs).IsEmpty();
        _ = await Assert.That(subject.Parameters).IsEmpty();
        _ = await Assert.That(subject.IsUndefined).IsTrue();
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
        _ = await Assert.That(subject.Condition).IsEqualTo(Snippet.From(TargetTaskTestsData.DefaultCondition));
        _ = await Assert.That(subject.ContinueOnError).IsEqualTo(TargetTask.Options.WarnAndContinue);
        _ = await Assert.That(subject.Name).IsEqualTo(new Name(TargetTaskTestsData.DefaultName));
        _ = await Assert.That(subject.Outputs).IsEqualTo(new[] { output });
        _ = await Assert.That(subject.Parameters).IsEqualTo(new[] { parameter });
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}