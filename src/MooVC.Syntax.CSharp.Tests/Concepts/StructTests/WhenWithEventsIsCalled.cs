namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;

public sealed class WhenWithEventsIsCalled
{
    [Test]
    public async Task GivenEventsThenReturnsUpdatedInstance()
    {
        // Arrange
        var @event = new Event { Name = new Name("Changed") };
        Struct original = StructTestsData.Create();

        // Act
        Struct result = original.WithEvents(@event);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Events).Contains(@event);
        await Assert.That(original.Events).IsEmpty();
    }
}