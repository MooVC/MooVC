namespace MooVC.Syntax.CSharp.Members.PropertyTests;

public sealed class WhenWithDefaultIsCalled
{
    [Fact]
    public void GivenDefaultThenReturnsUpdatedInstance()
    {
        // Arrange
        Property original = PropertyTestsData.Create();
        var defaultValue = Snippet.From("value");

        // Act
        Property result = original.WithDefault(defaultValue);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Behaviours.ShouldBe(original.Behaviours);
        result.Default.ShouldBe(defaultValue);
        result.Name.ShouldBe(original.Name);
        result.Scope.ShouldBe(original.Scope);
        result.Type.ShouldBe(original.Type);

        original.Default.ShouldBe(Snippet.Empty);
    }
}