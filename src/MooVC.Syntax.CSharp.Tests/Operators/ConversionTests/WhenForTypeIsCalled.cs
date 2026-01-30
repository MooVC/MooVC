namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenForTypeIsCalled
{
    [Fact]
    public void GivenSubjectThenReturnsNewInstanceWithUpdatedSubject()
    {
        // Arrange
        Conversion original = ConversionTestsData.Create();
        var replacement = new Symbol { Name = "Other" };

        // Act
        Conversion result = original.ForType(replacement);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(original.Body);
        result.Direction.ShouldBe(original.Direction);
        result.Mode.ShouldBe(original.Mode);
        result.Scope.ShouldBe(original.Scope);
        result.Target.ShouldBe(replacement);
    }
}