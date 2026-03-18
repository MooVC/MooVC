namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;

public sealed class WhenWithEventsIsCalled
{
    [Test]
    public async Task GivenEventsThenReturnsUpdatedInstance()
    {
        // Arrange
        var @event = new Event { Name = new Name("Created") };
        Interface original = InterfaceTestsData.Create();

        // Act
        Interface result = original.WithEvents(@event);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Events).Contains(@event);
        await Assert.That(original.Events).IsEmpty();
    }
}