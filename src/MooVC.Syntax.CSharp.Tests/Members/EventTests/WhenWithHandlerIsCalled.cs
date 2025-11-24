namespace MooVC.Syntax.CSharp.Members.EventTests;

public sealed class WhenWithHandlerIsCalled
{
    private const string Handler = "Handled";

    [Fact]
    public void GivenHandlerThenReturnsNewInstanceWithUpdatedHandler()
    {
        // Arrange
        Event original = EventTestsData.Create();
        var handler = new Symbol { Name = Handler };

        // Act
        Event result = original.WithHandler(handler);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Handler.ShouldBe(handler);
        result.Behaviours.ShouldBe(original.Behaviours);
        result.Name.ShouldBe(original.Name);
    }
}
