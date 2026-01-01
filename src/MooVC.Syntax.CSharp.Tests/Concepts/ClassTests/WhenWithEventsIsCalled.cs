namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System.Collections.Immutable;
using System.Linq;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithEventsIsCalled
{
    [Fact]
    public void GivenEventsThenReturnsUpdatedInstance()
    {
        // Arrange
        Event[] existing = [new Event { Name = new Variable("Created") }];
        Event[] additional = [new Event { Name = new Variable("Updated") }];
        Class original = ClassTestsData.Create(events: existing.ToImmutableArray());

        // Act
        Class result = original.WithEvents(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Events.ShouldBe(original.Events.Concat(additional));
        result.Scope.ShouldBe(original.Scope);
        original.Events.ShouldBe(existing);
    }
}