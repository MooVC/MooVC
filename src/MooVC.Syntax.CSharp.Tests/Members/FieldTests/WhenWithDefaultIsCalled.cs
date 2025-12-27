namespace MooVC.Syntax.CSharp.Members.FieldTests;

public sealed class WhenWithDefaultIsCalled
{
    [Fact]
    public void GivenDefaultThenReturnsNewInstanceWithUpdatedDefault()
    {
        // Arrange
        Field original = FieldTestsData.Create();
        var @default = Snippet.From("default");

        // Act
        Field result = original.WithDefault(@default);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Default.ShouldBe(@default);
        result.IsReadOnly.ShouldBe(original.IsReadOnly);
        result.IsStatic.ShouldBe(original.IsStatic);
        result.Name.ShouldBe(original.Name);
        result.Scope.ShouldBe(original.Scope);
        result.Type.ShouldBe(original.Type);

        original.Default.ShouldBe(Snippet.Empty);
    }
}