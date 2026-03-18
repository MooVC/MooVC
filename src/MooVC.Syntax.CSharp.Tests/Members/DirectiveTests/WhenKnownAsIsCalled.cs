namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

using MooVC.Syntax.Elements;

public sealed class WhenKnownAsIsCalled
{
    private const string Alias = "Alias";
    private const string NewAlias = "NewAlias";

    [Test]
    public async Task GivenValueThenReturnsNewInstanceWithUpdatedAlias()
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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Alias).IsEqualTo(new Name(NewAlias));
        _ = await Assert.That(result.IsStatic).IsEqualTo(original.IsStatic);
        _ = await Assert.That(result.Qualifier).IsEqualTo(original.Qualifier);
        _ = await Assert.That(original.Alias).IsEqualTo(new Name(Alias));
    }
}