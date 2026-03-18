namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithRemoveIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        var remove = Snippet.From("result");

        // Act
        Event.Methods result = original.WithRemove(remove);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Remove).IsEqualTo(remove);
        await Assert.That(result.Add).IsEqualTo(original.Add);
        await Assert.That(original.Remove).IsEqualTo(Snippet.Empty);
    }
}