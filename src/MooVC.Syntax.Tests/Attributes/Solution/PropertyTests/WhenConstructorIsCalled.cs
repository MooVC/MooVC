namespace MooVC.Syntax.Attributes.Solution.PropertyTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenPropertyIsUndefined()
    {
        // Act
        var subject = new Property();

        // Assert
        subject.Name.ShouldBe(Snippet.Empty);
        subject.Value.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Property
        {
            Name = Snippet.From(PropertyTestsData.DefaultName),
            Value = Snippet.From(PropertyTestsData.DefaultValue),
        };

        // Assert
        subject.Name.ShouldBe(Snippet.From(PropertyTestsData.DefaultName));
        subject.Value.ShouldBe(Snippet.From(PropertyTestsData.DefaultValue));
        subject.IsUndefined.ShouldBeFalse();
    }
}