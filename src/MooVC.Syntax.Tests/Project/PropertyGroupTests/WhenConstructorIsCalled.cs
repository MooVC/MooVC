namespace MooVC.Syntax.Project.PropertyGroupTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenPropertyGroupIsUndefined()
    {
        // Act
        var subject = new PropertyGroup();

        // Assert
        _ = await Assert.That(subject.Condition).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Label).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Properties).IsEmpty();
        _ = await Assert.That(subject.IsUndefined).IsTrue();
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
        _ = await Assert.That(subject.Condition).IsEqualTo(Snippet.From(PropertyGroupTestsData.DefaultCondition));
        _ = await Assert.That(subject.Label).IsEqualTo(Snippet.From(PropertyGroupTestsData.DefaultLabel));
        _ = await Assert.That(subject.Properties).IsEquivalentTo([property]);
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}