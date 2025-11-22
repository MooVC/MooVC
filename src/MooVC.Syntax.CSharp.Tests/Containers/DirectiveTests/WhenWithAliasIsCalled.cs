namespace MooVC.Syntax.CSharp.Containers.DirectiveTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithAliasIsCalled
{
    private const string Alias = "Alias";
    private const string NewAlias = "NewAlias";

    [Fact]
    public void GivenValueThenReturnsNewInstanceWithUpdatedAlias()
    {
        // Arrange
        var original = new Directive
        {
            Alias = new Identifier(Alias),
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        // Act
        Directive result = original.WithAlias(NewAlias);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Alias.ShouldBe(new Identifier(NewAlias));
        result.IsStatic.ShouldBe(original.IsStatic);
        result.Qualifier.ShouldBe(original.Qualifier);
        original.Alias.ShouldBe(new Identifier(Alias));
    }
}