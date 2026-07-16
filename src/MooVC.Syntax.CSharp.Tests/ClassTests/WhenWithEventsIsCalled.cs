namespace MooVC.Syntax.CSharp.ClassTests;

using System.Collections.Immutable;

public sealed class WhenWithEventsIsCalled
{
    [Test]
    public async Task GivenEventsThenReturnsUpdatedInstance()
    {
        // Arrange
        Event[] existing = [new() { Name = new("Created") }];
        Event[] additional = [new() { Name = new("Updated") }];
        Class original = ClassTestsData.Create(events: existing.ToImmutableArray());

        // Act
        Class result = original.WithEvents(additional);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Events).IsEquivalentTo([.. original.Events, .. additional]);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
        _ = await Assert.That(original.Events).IsEquivalentTo(existing);
    }
}