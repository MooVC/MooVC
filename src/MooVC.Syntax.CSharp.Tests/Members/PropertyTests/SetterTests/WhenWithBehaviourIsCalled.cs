namespace MooVC.Syntax.CSharp.Members.PropertyTests.SetterTests;

public sealed class WhenWithBehaviourIsCalled
{
    [Fact]
    public void GivenBehaviourThenReturnsUpdatedInstance()
    {
        // Arrange
        Property.Setter original = new Property.Setter();
        Snippet behaviour = Snippet.From("value = input");

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
