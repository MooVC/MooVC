namespace MooVC.Syntax.CSharp.Members.EventTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithBehavioursIsCalled
{
    [Fact]
    public void GivenBehavioursThenReturnsNewInstanceWithUpdatedBehaviours()
    {
        // Arrange
        Event original = EventTestsData.Create();

        var behaviours = new Event.Methods
        {
            Add = Snippet.From("add => value"),
        };

        // Act
        Event result = original.WithBehaviours(behaviours);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Behaviours.ShouldBe(behaviours);
        result.Handler.ShouldBe(original.Handler);
        result.Name.ShouldBe(original.Name);
    }
}