namespace MooVC.Syntax.Attributes.Project.OutputTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenTaskOutputIsUndefined()
    {
        // Act
        var subject = new Output();

        // Assert
        await Assert.That(subject.Condition).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.ItemName).IsEqualTo(Name.Unnamed);
        await Assert.That(subject.PropertyName).IsEqualTo(Name.Unnamed);
        await Assert.That(subject.TaskParameter).IsEqualTo(Name.Unnamed);
        await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
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
        await Assert.That(subject.Condition).IsEqualTo(Snippet.From(OutputTestsData.DefaultCondition));
        await Assert.That(subject.ItemName).IsEqualTo(new Name(OutputTestsData.DefaultItemName));
        await Assert.That(subject.PropertyName).IsEqualTo(new Name(OutputTestsData.DefaultPropertyName));
        await Assert.That(subject.TaskParameter).IsEqualTo(new Name(OutputTestsData.DefaultTaskParameter));
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}