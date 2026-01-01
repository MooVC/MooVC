namespace MooVC.Syntax.Attributes.Resource.HeaderTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenHeaderIsUndefined()
    {
        // Act
        var subject = new Header();

        // Assert
        subject.Name.ShouldBe(Snippet.Empty);
        subject.Value.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Snippet name = Snippet.From(HeaderTestsData.DefaultName);
        Snippet value = Snippet.From(HeaderTestsData.DefaultValue);

        // Act
        var subject = new Header
        {
            Name = name,
            Value = value,
        };

        // Assert
        subject.Name.ShouldBe(name);
        subject.Value.ShouldBe(value);
        subject.IsUndefined.ShouldBeFalse();
    }
}