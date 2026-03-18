namespace MooVC.Syntax.Attributes.Project.MetadataTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenMetadataIsUndefined()
    {
        // Act
        var subject = new Metadata();

        // Assert
        await Assert.That(subject.Condition).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Name).IsEqualTo(Name.Unnamed);
        await Assert.That(subject.Value).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Metadata
        {
            Condition = Snippet.From(MetadataTestsData.DefaultCondition),
            Name = MetadataTestsData.DefaultName,
            Value = Snippet.From(MetadataTestsData.DefaultValue),
        };

        // Assert
        await Assert.That(subject.Condition).IsEqualTo(Snippet.From(MetadataTestsData.DefaultCondition));
        await Assert.That(subject.Name).IsEqualTo(new Name(MetadataTestsData.DefaultName));
        await Assert.That(subject.Value).IsEqualTo(Snippet.From(MetadataTestsData.DefaultValue));
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}