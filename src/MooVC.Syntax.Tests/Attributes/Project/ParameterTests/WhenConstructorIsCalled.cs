namespace MooVC.Syntax.Attributes.Project.ParameterTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenTaskParameterIsUndefined()
    {
        // Act
        var subject = new Parameter();

        // Assert
        subject.Name.ShouldBe(Identifier.Unnamed);
        subject.Value.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Parameter
        {
            Name = new Identifier(ParameterTestsData.DefaultName),
            Value = Snippet.From(ParameterTestsData.DefaultValue),
        };

        // Assert
        subject.Name.ShouldBe(new Identifier(ParameterTestsData.DefaultName));
        subject.Value.ShouldBe(Snippet.From(ParameterTestsData.DefaultValue));
        subject.IsUndefined.ShouldBeFalse();
    }
}