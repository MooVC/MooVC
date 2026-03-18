namespace MooVC.Syntax.CSharp.PropertyTests.SetterTests;

public sealed class WhenWithBehaviourIsCalled
{
    [Test]
    public async Task GivenBehaviourThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Property.Setter();
        var behaviour = Snippet.From("value = input");

        // Act
        Property.Setter result = original.WithBehaviour(behaviour);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Behaviour).IsEqualTo(behaviour);
        _ = await Assert.That(result.Mode).IsEqualTo(original.Mode);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);

        _ = await Assert.That(original.Behaviour).IsEqualTo(Snippet.Empty);
    }
}