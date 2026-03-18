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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Behaviours).IsEqualTo(behaviours);
        _ = await Assert.That(result.Handler).IsEqualTo(original.Handler);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}