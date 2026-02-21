namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenFromIsCalled
{
    [Fact]
    public void GivenValueThenReturnsNewInstanceWithUpdatedQualifier()
    {
        // Arrange
        var original = new Directive
        {
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        var qualifier = new Qualifier(["MooVC", "Syntax", "CSharp"]);

        // Act
        Directive result = original.From(qualifier);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Alias.ShouldBe(original.Alias);
        result.IsStatic.ShouldBe(original.IsStatic);
        result.Qualifier.ShouldBe(qualifier);
        original.Qualifier.ShouldBe(new Qualifier(["MooVC", "Syntax"]));
    }
}