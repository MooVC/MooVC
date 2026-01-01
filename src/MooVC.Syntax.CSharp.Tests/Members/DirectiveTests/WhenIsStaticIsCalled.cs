namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenIsStaticIsCalled
{
    [Fact]
    public void GivenValueThenReturnsNewInstanceWithUpdatedStaticState()
    {
        // Arrange
        var original = new Directive
        {
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        // Act
        Directive result = original.IsStatic(true);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.IsStatic.ShouldBeTrue();
        result.Alias.ShouldBe(original.Alias);
        result.Qualifier.ShouldBe(original.Qualifier);
        original.IsStatic.ShouldBeFalse();
    }
}