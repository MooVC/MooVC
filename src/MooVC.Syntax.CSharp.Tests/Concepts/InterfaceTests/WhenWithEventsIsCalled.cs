namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithEventsIsCalled
{
    [Fact]
    public void GivenEventsThenReturnsUpdatedInstance()
    {
        // Arrange
        var @event = new Event { Name = new Identifier("Created") };
        Interface original = InterfaceTestsData.Create();

        // Act
        Interface result = original.WithEvents(@event);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Events.ShouldContain(@event);
        original.Events.ShouldBeEmpty();
    }
}