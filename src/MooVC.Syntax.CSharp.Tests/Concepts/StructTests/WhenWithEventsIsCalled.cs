namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;

public sealed class WhenWithEventsIsCalled
{
    [Fact]
    public void GivenEventsThenReturnsUpdatedInstance()
    {
        // Arrange
        var @event = new Event { Name = "Changed" };
        Struct original = StructTestsData.Create();

        // Act
        Struct result = original.WithEvents(@event);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Events.ShouldContain(@event);
        original.Events.ShouldBeEmpty();
    }
}