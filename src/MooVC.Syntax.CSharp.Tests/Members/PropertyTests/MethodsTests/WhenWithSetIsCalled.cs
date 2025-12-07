namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

public sealed class WhenWithSetIsCalled
{
    [Fact]
    public void GivenSetterThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Property.Methods
        {
            Get = Snippet.From("value"),
        };

        var set = new Property.Setter
        {
            Behaviour = Snippet.From("value = input"),
            Mode = Property.Mode.Init,
            Scope = Scope.Private,
        };

        // Act
        Property.Methods result = original.WithSet(set);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Get.ShouldBe(original.Get);
        result.Set.ShouldBe(set);
        original.Set.ShouldBe(Property.Setter.Default);
    }
}
