namespace MooVC.Syntax.CSharp.Operators.ComparisonTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenComparisonIsUndefined()
    {
        // Act
        var subject = new Comparison();

        // Assert
        await Assert.That(subject.Body).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.IsUndefined).IsTrue();
        await Assert.That(subject.Operator).IsEqualTo(Comparison.Type.Unspecified);
        await Assert.That(subject.Scope).IsEqualTo(Scope.Public);
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
            Operator = Comparison.Type.GreaterThan,
            Scope = Scope.Private,
        };

        // Assert
        await Assert.That(subject.Body).IsEqualTo(body);
        await Assert.That(subject.IsUndefined).IsFalse();
        await Assert.That(subject.Operator).IsEqualTo(Comparison.Type.GreaterThan);
        await Assert.That(subject.Scope).IsEqualTo(Scope.Private);
    }
}