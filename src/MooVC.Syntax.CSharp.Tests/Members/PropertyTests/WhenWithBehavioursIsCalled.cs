namespace MooVC.Syntax.CSharp.Members.PropertyTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithBehavioursIsCalled
{
    [Fact]
    public void GivenBehavioursThenReturnsUpdatedInstance()
    {
        // Arrange
        Property original = PropertyTestsData.Create();
        var behaviours = new Property.Methods
        {
            Get = Snippet.From("value"),
        };

        // Act
        Property result = original.WithBehaviours(behaviours);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Behaviours.ShouldBe(behaviours);
        result.Default.ShouldBe(original.Default);
        result.Name.ShouldBe(original.Name);
        result.Scope.ShouldBe(original.Scope);
        result.Type.ShouldBe(original.Type);

        original.Behaviours.ShouldNotBe(behaviours);
    }
}