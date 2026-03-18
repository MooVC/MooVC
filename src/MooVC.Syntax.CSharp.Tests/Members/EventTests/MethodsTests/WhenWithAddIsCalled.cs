namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithAddIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Event.Methods
        {
            Remove = Snippet.From("value"),
        };

        var add = Snippet.From("result");

        // Act
        Event.Methods result = original.WithAdd(add);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Add).IsEqualTo(add);
        await Assert.That(result.Remove).IsEqualTo(original.Remove);
        await Assert.That(original.Add).IsEqualTo(Snippet.Empty);
    }
}