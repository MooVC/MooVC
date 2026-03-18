namespace MooVC.Syntax.Attributes.Project.PropertyGroupTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenPropertyGroupIsUndefined()
    {
        // Act
        var subject = new PropertyGroup();

        // Assert
        await Assert.That(subject.Condition).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Label).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Properties).IsEmpty();
        await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Property property = PropertyGroupTestsData.CreateProperty();

        // Act
        var subject = new PropertyGroup
        {
            Condition = Snippet.From(PropertyGroupTestsData.DefaultCondition),
            Label = Snippet.From(PropertyGroupTestsData.DefaultLabel),
            Properties = [property],
        };

        // Assert
        await Assert.That(subject.Condition).IsEqualTo(Snippet.From(PropertyGroupTestsData.DefaultCondition));
        await Assert.That(subject.Label).IsEqualTo(Snippet.From(PropertyGroupTestsData.DefaultLabel));
        await Assert.That(subject.Properties).IsEqualTo(new[] { property });
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}