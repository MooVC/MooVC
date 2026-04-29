namespace MooVC.Syntax.CSharp.EventTests.MethodsTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenInstanceIsDefault()
    {
        // Act
        var subject = new Event.Methods();

        // Assert
        _ = await Assert.That(subject.Add).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Remove).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.IsDefault).IsTrue();
        _ = await Assert.That(subject).IsEqualTo(Event.Methods.Default);
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var add = Snippet.From("value");
        var remove = Snippet.From("result");

        // Act
        var subject = new Event.Methods
        {
            Add = add,
            Remove = remove,
        };

        // Assert
        _ = await Assert.That(subject.Add).IsEqualTo(add);
        _ = await Assert.That(subject.Remove).IsEqualTo(remove);
        _ = await Assert.That(subject.IsDefault).IsFalse();
    }
}