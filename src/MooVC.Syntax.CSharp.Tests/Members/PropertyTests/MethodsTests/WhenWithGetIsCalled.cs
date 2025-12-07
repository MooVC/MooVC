namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

public sealed class WhenWithGetIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Property.Methods
        {
            Set = new Property.Setter { Behaviour = Snippet.From("value = input") },
        };

        var get = Snippet.From("result");

        // Act
        Property.Methods result = original.WithGet(get);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Get.ShouldBe(get);
        result.Set.ShouldBe(original.Set);
        original.Get.ShouldBe(Snippet.Empty);
    }
}
