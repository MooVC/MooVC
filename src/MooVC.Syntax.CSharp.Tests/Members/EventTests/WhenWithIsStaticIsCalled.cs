namespace MooVC.Syntax.CSharp.Members.EventTests;

public sealed class WhenWithIsStaticIsCalled
{
    [Fact]
    public void GivenValueThenReturnsNewInstanceWithUpdatedStaticState()
    {
        // Arrange
        Event original = EventTestsData.Create();

        // Act
        Event result = original.WithIsStatic(true);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.IsStatic.ShouldBeTrue();
        result.Behaviours.ShouldBe(original.Behaviours);
        result.Handler.ShouldBe(original.Handler);
        result.Name.ShouldBe(original.Name);
        result.Scope.ShouldBe(original.Scope);
        original.IsStatic.ShouldBeFalse();
    }
}
