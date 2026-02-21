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
            Name = PropertyTestsData.DefaultName,
            Value = PropertyTestsData.DefaultValue,
        };

        // Assert
        subject.Name.ShouldBe(PropertyTestsData.DefaultName);
        subject.Value.ShouldBe(PropertyTestsData.DefaultValue);
        subject.IsUndefined.ShouldBeFalse();
    }
}