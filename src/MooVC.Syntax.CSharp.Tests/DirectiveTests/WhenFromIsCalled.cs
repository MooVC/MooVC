namespace MooVC.Syntax.CSharp.DirectiveTests;

public sealed class WhenFromIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsNewInstanceWithUpdatedQualifier()
    {
        // Arrange
        var original = new Directive
        {
            Qualifier = new(["MooVC", "Syntax"]),
        };

        var qualifier = new Qualifier(["MooVC", "Syntax", "CSharp"]);

        // Act
        Directive result = original.From(qualifier);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Alias).IsEqualTo(original.Alias);
        _ = await Assert.That(result.IsStatic).IsEqualTo(original.IsStatic);
        _ = await Assert.That(result.Qualifier).IsEqualTo(qualifier);
        _ = await Assert.That(original.Qualifier).IsEqualTo(new Qualifier(["MooVC", "Syntax"]));
    }
}