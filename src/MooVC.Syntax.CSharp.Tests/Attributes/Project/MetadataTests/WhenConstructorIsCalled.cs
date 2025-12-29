namespace MooVC.Syntax.CSharp.Attributes.Project.MetadataTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenMetadataIsUndefined()
    {
        // Act
        var subject = new Metadata();

        // Assert
        subject.Condition.ShouldBe(Snippet.Empty);
        subject.Name.ShouldBe(Identifier.Unnamed);
        subject.Value.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Metadata
        {
            Condition = Snippet.From(MetadataTestsData.DefaultCondition),
            Name = new Identifier(MetadataTestsData.DefaultName),
            Value = Snippet.From(MetadataTestsData.DefaultValue),
        };

        // Assert
        subject.Condition.ShouldBe(Snippet.From(MetadataTestsData.DefaultCondition));
        subject.Name.ShouldBe(new Identifier(MetadataTestsData.DefaultName));
        subject.Value.ShouldBe(Snippet.From(MetadataTestsData.DefaultValue));
        subject.IsUndefined.ShouldBeFalse();
    }
}