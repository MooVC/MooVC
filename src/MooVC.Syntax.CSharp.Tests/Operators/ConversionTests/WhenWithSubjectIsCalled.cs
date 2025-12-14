namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

public sealed class WhenWithSubjectIsCalled
{
    [Fact]
    public void GivenSubjectThenReturnsNewInstanceWithUpdatedSubject()
    {
        // Arrange
        Conversion original = ConversionTestsData.Create();
        Symbol replacement = Symbol.From("Other");

        // Act
        Conversion result = original.WithSubject(replacement);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(original.Body);
        result.Direction.ShouldBe(original.Direction);
        result.Mode.ShouldBe(original.Mode);
        result.Scope.ShouldBe(original.Scope);
        result.Subject.ShouldBe(replacement);
    }
}
