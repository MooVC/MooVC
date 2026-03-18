namespace MooVC.Syntax.CSharp.Members.EventTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithBehavioursIsCalled
{
    [Test]
    public async Task GivenBehavioursThenReturnsNewInstanceWithUpdatedBehaviours()
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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Behaviours).IsEqualTo(behaviours);
        await Assert.That(result.Handler).IsEqualTo(original.Handler);
        await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}