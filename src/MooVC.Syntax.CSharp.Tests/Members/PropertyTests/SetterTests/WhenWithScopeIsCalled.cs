namespace MooVC.Syntax.CSharp.Members.PropertyTests.SetterTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenWithScopeIsCalled
{
    [Fact]
    public void GivenScopeThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Property.Setter { Scope = Scope.Internal };

        // Act
        Property.Setter result = original.WithScope(Scope.Private);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Behaviour.ShouldBe(original.Behaviour);
        result.Mode.ShouldBe(original.Mode);
        result.Scope.ShouldBe(Scope.Private);

        original.Scope.ShouldBe(Scope.Internal);
    }
}