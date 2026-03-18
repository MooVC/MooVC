namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System.Collections.Immutable;
using System.Linq;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;

public sealed class WhenWithEventsIsCalled
{
    [Test]
    public async Task GivenEventsThenReturnsUpdatedInstance()
    {
        // Arrange
        Event[] existing = [new Event { Name = new Name("Created") }];
        Event[] additional = [new Event { Name = new Name("Updated") }];
        Class original = ClassTestsData.Create(events: existing.ToImmutableArray());

        // Act
        Class result = original.WithEvents(additional);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Events).IsEqualTo(original.Events.Concat(additional));
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
        await Assert.That(original.Events).IsEqualTo(existing);
    }
}