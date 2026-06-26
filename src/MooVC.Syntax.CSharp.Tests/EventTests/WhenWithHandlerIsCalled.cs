namespace MooVC.Syntax.CSharp.EventTests;

public sealed class WhenWithHandlerIsCalled
{
    private const string Handler = "Handled";

    [Test]
    public async Task GivenHandlerThenReturnsNewInstanceWithUpdatedHandler()
    {
        // Arrange
        Event original = EventTestsData.Create();
        var handler = new Symbol { Name = Handler };

        // Act
        Event result = original.WithHandler(handler);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Handler).IsEqualTo(handler);
        _ = await Assert.That(result.Behaviours).IsEqualTo(original.Behaviours);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}