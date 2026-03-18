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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Alias).IsEqualTo(new Name(NewAlias));
        await Assert.That(result.IsStatic).IsEqualTo(original.IsStatic);
        await Assert.That(result.Qualifier).IsEqualTo(original.Qualifier);
        await Assert.That(original.Alias).IsEqualTo(new Name(Alias));
    }
}