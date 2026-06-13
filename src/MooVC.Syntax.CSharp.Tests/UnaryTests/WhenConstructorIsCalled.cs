namespace MooVC.Syntax.CSharp.UnaryTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenUnaryIsUndefined()
    {
        // Act
        var subject = new Unary();

        // Assert
        _ = await Assert.That(subject.Body).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
        _ = await Assert.That(subject.Operator).IsEqualTo(Unary.Types.Unspecified);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scopes.Public);
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var body = Snippet.From(UnaryTestsData.DefaultBody);

        // Act
        var subject = new Unary
        {
            Body = body,
            Operator = Unary.Types.Not,
            Scope = Scopes.Private,
        };

        // Assert
        _ = await Assert.That(subject.Body).IsEqualTo(body);
        _ = await Assert.That(subject.IsUndefined).IsFalse();
        _ = await Assert.That(subject.Operator).IsEqualTo(Unary.Types.Not);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scopes.Private);
    }
}