namespace MooVC.Syntax.CSharp.Members.PropertyTests.SetterTests;

public sealed class WhenWithModeIsCalled
{
    [Fact]
    public void GivenModeThenReturnsUpdatedInstance()
    {
        // Arrange
        Property.Setter original = new Property.Setter { Mode = Property.Mode.Set };

        // Act
        Property.Setter result = original.WithMode(Property.Mode.Init);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Behaviour.ShouldBe(original.Behaviour);
        result.Mode.ShouldBe(Property.Mode.Init);
        result.Scope.ShouldBe(original.Scope);

        original.Mode.ShouldBe(Property.Mode.Set);
    }
}
