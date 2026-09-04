namespace MooVC.Syntax.CSharp.PropertyTests.MethodsTests;

public sealed class WhenWithGetIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Property.Methods
        {
            Set = new() { Behaviour = Snippet.From("value = input") },
        };

        var get = Snippet.From("result");

        // Act
        Property.Methods result = original.WithGet(get);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Get).IsEqualTo(get);
        _ = await Assert.That(result.Set).IsEqualTo(original.Set);
        _ = await Assert.That(original.Get).IsEqualTo(Snippet.Empty);
    }
}