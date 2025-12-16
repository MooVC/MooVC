namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithEventsIsCalled
{
    [Fact]
    public void GivenEventsThenReturnsUpdatedInstance()
    {
        // Arrange
        var @event = new Event { Name = new Identifier("Changed") };
        Struct original = StructTestsData.Create();

        // Act
        Struct result = original.WithEvents(@event);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Events.ShouldContain(@event);
        original.Events.ShouldBeEmpty();
    }
}
