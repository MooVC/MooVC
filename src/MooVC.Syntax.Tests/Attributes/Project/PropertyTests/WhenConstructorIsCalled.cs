namespace MooVC.Syntax.Attributes.Project.PropertyTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenPropertyIsUndefined()
    {
        // Act
        var subject = new Property();

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
        var subject = new Property
        {
            Condition = Snippet.From(PropertyTestsData.DefaultCondition),
            Name = PropertyTestsData.DefaultName,
            Value = Snippet.From(PropertyTestsData.DefaultValue),
        };

        // Assert
        _ = await Assert.That(subject.Condition).IsEqualTo(Snippet.From(PropertyTestsData.DefaultCondition));
        _ = await Assert.That(subject.Name).IsEqualTo(new Name(PropertyTestsData.DefaultName));
        _ = await Assert.That(subject.Value).IsEqualTo(Snippet.From(PropertyTestsData.DefaultValue));
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}