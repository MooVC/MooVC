namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithBodyIsCalled
{
    [Fact]
    public void GivenBodyThenReturnsNewInstanceWithUpdatedBody()
    {
        // Arrange
        Conversion original = ConversionTestsData.Create(body: Snippet.From("return value;"));
        var replacement = Snippet.From("return other;");

        // Act
        Conversion result = original.WithBody(replacement);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(replacement);
        result.Direction.ShouldBe(original.Direction);
        result.Mode.ShouldBe(original.Mode);
        result.Scope.ShouldBe(original.Scope);
        result.Target.ShouldBe(original.Target);
    }
}