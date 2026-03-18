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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Add).IsEqualTo(add);
        _ = await Assert.That(result.Remove).IsEqualTo(original.Remove);
        _ = await Assert.That(original.Add).IsEqualTo(Snippet.Empty);
    }
}