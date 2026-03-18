namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;

public sealed class WhenWithEventsIsCalled
{
    [Test]
    public async Task GivenEventsThenReturnsUpdatedInstance()
    {
        // Arrange
        var created = new Event { Name = new Name("Created") };
        var updated = new Event { Name = new Name("Updated") };
        Record original = RecordTestsData.Create(events: [created]);

        // Act
        Record result = original.WithEvents(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Events).IsEqualTo(new[] { created, updated });
        await Assert.That(result.Fields).IsEqualTo(original.Fields);
    }
}