namespace MooVC.Syntax.CSharp.Members.EventTests;

public sealed class WhenIsStaticIsCalled
{
    [Fact]
    public void GivenValueThenReturnsNewInstanceWithUpdatedStaticState()
    {
        // Arrange
        Event original = EventTestsData.Create();

        // Act
        Event result = original.IsStatic(true);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.IsStatic.ShouldBeTrue();
        result.Behaviours.ShouldBe(original.Behaviours);
        result.Handler.ShouldBe(original.Handler);
        result.Name.ShouldBe(original.Name);
        original.IsStatic.ShouldBeFalse();
    }
}
