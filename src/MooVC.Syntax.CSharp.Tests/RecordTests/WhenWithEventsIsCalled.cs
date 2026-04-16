namespace MooVC.Syntax.CSharp.RecordTests;

public sealed class WhenWithEventsIsCalled
{
    [Test]
    public async Task GivenEventsThenReturnsUpdatedInstance()
    {
        // Arrange
        var created = new Event { Name = new("Created") };
        var updated = new Event { Name = new("Updated") };
        Record original = RecordTestsData.Create(events: [created]);

        // Act
        Record result = original.WithEvents(updated);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Events).IsEquivalentTo([created, updated]);
        _ = await Assert.That(result.Fields).IsEqualTo(original.Fields);
    }
}