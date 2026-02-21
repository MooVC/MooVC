namespace MooVC.Syntax.CSharp.Members.PropertyTests.SetterTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithBehaviourIsCalled
{
    [Fact]
    public void GivenBehaviourThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Property.Setter();
        var behaviour = "value = input";

        // Act
        Property.Setter result = original.WithBehaviour(behaviour);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Behaviour.ShouldBe(behaviour);
        result.Mode.ShouldBe(original.Mode);
        result.Scope.ShouldBe(original.Scope);

        original.Behaviour.ShouldBe(Snippet.Empty);
    }
}