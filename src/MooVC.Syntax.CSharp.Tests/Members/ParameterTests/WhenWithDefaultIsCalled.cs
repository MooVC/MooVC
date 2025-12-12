namespace MooVC.Syntax.CSharp.Members.ParameterTests;

public sealed class WhenWithDefaultIsCalled
{
    [Fact]
    public void GivenValueThenReturnsNewInstanceWithUpdatedDefault()
    {
        // Arrange
        Parameter original = ParameterTestsData.Create(modifier: Parameter.Mode.In);
        var @default = Snippet.From("value");

        // Act
        Parameter result = original.WithDefault(@default);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Default.ShouldBe(@default);
        result.Attributes.ShouldBe(original.Attributes);
        result.Modifier.ShouldBe(original.Modifier);
        result.Name.ShouldBe(original.Name);
        original.Default.ShouldBe(Snippet.Empty);
    }
}