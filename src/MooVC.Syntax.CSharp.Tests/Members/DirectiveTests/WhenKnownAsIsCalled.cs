namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

using MooVC.Syntax.Elements;

public sealed class WhenKnownAsIsCalled
{
    private const string Alias = "Alias";
    private const string NewAlias = "NewAlias";

    [Fact]
    public void GivenValueThenReturnsNewInstanceWithUpdatedAlias()
    {
        // Arrange
        var original = new Directive
        {
            Alias = new Name(Alias),
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        // Act
        Directive result = original.KnownAs(NewAlias);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Alias.ShouldBe(new Name(NewAlias));
        result.IsStatic.ShouldBe(original.IsStatic);
        result.Qualifier.ShouldBe(original.Qualifier);
        original.Alias.ShouldBe(new Name(Alias));
    }
}