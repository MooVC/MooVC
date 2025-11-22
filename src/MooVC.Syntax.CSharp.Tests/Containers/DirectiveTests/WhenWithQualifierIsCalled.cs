namespace MooVC.Syntax.CSharp.Containers.DirectiveTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithQualifierIsCalled
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
        Directive result = original.WithQualifier(qualifier);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Alias.ShouldBe(original.Alias);
        result.IsStatic.ShouldBe(original.IsStatic);
        result.Qualifier.ShouldBe(qualifier);
        original.Qualifier.ShouldBe(new Qualifier(["MooVC", "Syntax"]));
    }
}