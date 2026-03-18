namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenInstanceIsDefault()
    {
        // Act
        var subject = new Event.Methods();

        // Assert
        await Assert.That(subject.Add).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Remove).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.IsDefault).IsTrue();
        await Assert.That(subject).IsEqualTo(Event.Methods.Default);
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
        await Assert.That(subject.Add).IsEqualTo(add);
        await Assert.That(subject.Remove).IsEqualTo(remove);
        await Assert.That(subject.IsDefault).IsFalse();
    }
}