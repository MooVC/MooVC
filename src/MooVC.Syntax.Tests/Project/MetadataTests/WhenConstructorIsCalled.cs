namespace MooVC.Syntax.Project.MetadataTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenMetadataIsUndefined()
    {
        // Act
        var subject = new Metadata();

        // Assert
        _ = await Assert.That(subject.Condition).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Name).IsEqualTo(Name.Unnamed);
        _ = await Assert.That(subject.Value).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
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
        _ = await Assert.That(subject.Condition).IsEqualTo(Snippet.From(MetadataTestsData.DefaultCondition));
        _ = await Assert.That(subject.Name).IsEqualTo(new Name(MetadataTestsData.DefaultName));
        _ = await Assert.That(subject.Value).IsEqualTo(Snippet.From(MetadataTestsData.DefaultValue));
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}