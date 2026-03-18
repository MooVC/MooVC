namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenFromIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsNewInstanceWithUpdatedQualifier()
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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Alias).IsEqualTo(original.Alias);
        await Assert.That(result.IsStatic).IsEqualTo(original.IsStatic);
        await Assert.That(result.Qualifier).IsEqualTo(qualifier);
        await Assert.That(original.Qualifier).IsEqualTo(new Qualifier(["MooVC", "Syntax"]));
    }
}