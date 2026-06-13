namespace MooVC.Syntax.CSharp.ComparisonTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenComparisonIsUndefined()
    {
        // Act
        var subject = new Comparison();

        // Assert
        _ = await Assert.That(subject.Body).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
        _ = await Assert.That(subject.Operator).IsEqualTo(Comparison.Types.Unspecified);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scopes.Public);
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var body = Snippet.From(ComparisonTestsData.DefaultBody);

        // Act
        var subject = new Comparison
        {
            Body = body,
            Operator = Comparison.Types.GreaterThan,
            Scope = Scopes.Private,
        };

        // Assert
        _ = await Assert.That(subject.Body).IsEqualTo(body);
        _ = await Assert.That(subject.IsUndefined).IsFalse();
        _ = await Assert.That(subject.Operator).IsEqualTo(Comparison.Types.GreaterThan);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scopes.Private);
    }
}