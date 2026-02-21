namespace MooVC.Syntax.Attributes.Project.MetadataTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenMetadataIsUndefined()
    {
        // Act
        var subject = new Metadata();

        // Assert
        subject.Condition.ShouldBe(Snippet.Empty);
        subject.Name.ShouldBe(Name.Unnamed);
        subject.Value.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Metadata
        {
            Condition = MetadataTestsData.DefaultCondition,
            Name = MetadataTestsData.DefaultName,
            Value = MetadataTestsData.DefaultValue,
        };

        // Assert
        subject.Condition.ShouldBe(MetadataTestsData.DefaultCondition);
        subject.Name.ShouldBe(MetadataTestsData.DefaultName);
        subject.Value.ShouldBe(MetadataTestsData.DefaultValue);
        subject.IsUndefined.ShouldBeFalse();
    }
}