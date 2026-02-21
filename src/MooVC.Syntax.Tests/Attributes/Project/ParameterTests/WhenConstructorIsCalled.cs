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
        subject.Name.ShouldBe(Name.Unnamed);
        subject.Value.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Parameter
        {
            Name = ParameterTestsData.DefaultName,
            Value = ParameterTestsData.DefaultValue,
        };

        // Assert
        subject.Name.ShouldBe(ParameterTestsData.DefaultName);
        subject.Value.ShouldBe(ParameterTestsData.DefaultValue);
        subject.IsUndefined.ShouldBeFalse();
    }
}