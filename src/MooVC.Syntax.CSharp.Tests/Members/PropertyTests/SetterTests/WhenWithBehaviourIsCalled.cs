namespace MooVC.Syntax.CSharp.Members.PropertyTests.SetterTests;

using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Behaviour).IsEqualTo(behaviour);
        await Assert.That(result.Mode).IsEqualTo(original.Mode);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);

        await Assert.That(original.Behaviour).IsEqualTo(Snippet.Empty);
    }
}