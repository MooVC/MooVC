namespace MooVC.Syntax.CSharp.StructTests;

public sealed class WhenWithEventsIsCalled
{
    [Test]
    public async Task GivenEventsThenReturnsUpdatedInstance()
    {
        // Arrange
        var @event = new Event { Name = new("Changed") };
        Struct original = StructTestsData.Create();

        // Act
        Struct result = original.WithEvents(@event);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Events).Contains(@event);
        _ = await Assert.That(original.Events).IsEmpty();
    }
}