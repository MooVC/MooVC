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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Remove).IsEqualTo(remove);
        _ = await Assert.That(result.Add).IsEqualTo(original.Add);
        _ = await Assert.That(original.Remove).IsEqualTo(Snippet.Empty);
    }
}