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
        _ = await Assert.That(subject.Condition).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.ItemName).IsEqualTo(Name.Unnamed);
        _ = await Assert.That(subject.PropertyName).IsEqualTo(Name.Unnamed);
        _ = await Assert.That(subject.TaskParameter).IsEqualTo(Name.Unnamed);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
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
        _ = await Assert.That(subject.Condition).IsEqualTo(Snippet.From(OutputTestsData.DefaultCondition));
        _ = await Assert.That(subject.ItemName).IsEqualTo(new Name(OutputTestsData.DefaultItemName));
        _ = await Assert.That(subject.PropertyName).IsEqualTo(new Name(OutputTestsData.DefaultPropertyName));
        _ = await Assert.That(subject.TaskParameter).IsEqualTo(new Name(OutputTestsData.DefaultTaskParameter));
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}