namespace MooVC.Syntax.Attributes.Project.TaskParameterTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenTaskParameterIsUndefined()
    {
        // Act
        var subject = new TaskParameter();

        // Assert
        subject.Name.ShouldBe(Identifier.Unnamed);
        subject.Value.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new TaskParameter
        {
            Name = new Identifier(TaskParameterTestsData.DefaultName),
            Value = Snippet.From(TaskParameterTestsData.DefaultValue),
        };

        // Assert
        subject.Name.ShouldBe(new Identifier(TaskParameterTestsData.DefaultName));
        subject.Value.ShouldBe(Snippet.From(TaskParameterTestsData.DefaultValue));
        subject.IsUndefined.ShouldBeFalse();
    }
}