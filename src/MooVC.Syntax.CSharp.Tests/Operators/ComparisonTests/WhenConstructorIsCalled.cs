namespace MooVC.Syntax.CSharp.Operators.ComparisonTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenComparisonIsUndefined()
    {
        // Act
        var subject = new Comparison();

        // Assert
        subject.Body.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
        subject.Operator.ShouldBe(Comparison.Type.Unspecified);
        subject.Scope.ShouldBe(Scope.Public);
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var body = ComparisonTestsData.DefaultBody;

        // Act
        var subject = new Comparison
        {
            Body = body,
            Operator = Comparison.Type.GreaterThan,
            Scope = Scope.Private,
        };

        // Assert
        subject.Body.ShouldBe(body);
        subject.IsUndefined.ShouldBeFalse();
        subject.Operator.ShouldBe(Comparison.Type.GreaterThan);
        subject.Scope.ShouldBe(Scope.Private);
    }
}