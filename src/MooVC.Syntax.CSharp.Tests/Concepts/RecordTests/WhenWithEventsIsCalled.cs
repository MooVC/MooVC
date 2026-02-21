namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;

public sealed class WhenWithEventsIsCalled
{
    [Fact]
    public void GivenEventsThenReturnsUpdatedInstance()
    {
        // Arrange
        var created = new Event { Name = "Created" };
        var updated = new Event { Name = "Updated" };
        Record original = RecordTestsData.Create(events: [created]);

        // Act
        Record result = original.WithEvents(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Events.ShouldBe(new[] { created, updated });
        result.Fields.ShouldBe(original.Fields);
    }
}