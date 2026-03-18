namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenUnaryIsUndefined()
    {
        // Act
        var subject = new Unary();

        // Assert
        await Assert.That(subject.Body).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.IsUndefined).IsTrue();
        await Assert.That(subject.Operator).IsEqualTo(Unary.Type.Unspecified);
        await Assert.That(subject.Scope).IsEqualTo(Scope.Public);
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
            Operator = Unary.Type.Not,
            Scope = Scope.Private,
        };

        // Assert
        await Assert.That(subject.Body).IsEqualTo(body);
        await Assert.That(subject.IsUndefined).IsFalse();
        await Assert.That(subject.Operator).IsEqualTo(Unary.Type.Not);
        await Assert.That(subject.Scope).IsEqualTo(Scope.Private);
    }
}