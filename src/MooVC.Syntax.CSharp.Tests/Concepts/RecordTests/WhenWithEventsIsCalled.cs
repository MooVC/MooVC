namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithEventsIsCalled
{
    [Fact]
    public void GivenEventsThenReturnsUpdatedInstance()
    {
        // Arrange
        var created = new Event { Name = new Identifier("Created") };
        var updated = new Event { Name = new Identifier("Updated") };
        Record original = RecordTestsData.Create(events: [created]);

        // Act
        Record result = original.WithEvents(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Events.ShouldBe(new[] { created, updated });
        result.Fields.ShouldBe(original.Fields);
    }
}
