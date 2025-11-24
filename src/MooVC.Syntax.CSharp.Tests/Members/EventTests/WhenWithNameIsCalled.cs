namespace MooVC.Syntax.CSharp.Members.EventTests;

public sealed class WhenWithNameIsCalled
{
    private const string Name = "Handled";

    [Fact]
    public void GivenNameThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        Event original = EventTestsData.Create();
        var name = new Identifier(Name);

        // Act
        Event result = original.WithName(name);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(name);
        result.Behaviours.ShouldBe(original.Behaviours);
        result.Handler.ShouldBe(original.Handler);
    }
}
