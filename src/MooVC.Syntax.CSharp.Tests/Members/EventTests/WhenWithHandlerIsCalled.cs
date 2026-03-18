namespace MooVC.Syntax.CSharp.Members.EventTests;

using MooVC.Syntax.CSharp.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Handler).IsEqualTo(handler);
        await Assert.That(result.Behaviours).IsEqualTo(original.Behaviours);
        await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}