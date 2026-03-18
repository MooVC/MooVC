namespace MooVC.Syntax.CSharp.Operators.BinaryTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenBinaryIsUndefined()
    {
        // Act
        var subject = new Binary();

        // Assert
        await Assert.That(subject.Body).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.IsUndefined).IsTrue();
        await Assert.That(subject.Operator).IsEqualTo(Binary.Type.Unspecified);
        await Assert.That(subject.Scope).IsEqualTo(Scope.Public);
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var body = Snippet.From(BinaryTestsData.DefaultBody);

        // Act
        var subject = new Binary
        {
            Body = body,
            Operator = Binary.Type.Multiply,
            Scope = Scope.Private,
        };

        // Assert
        await Assert.That(subject.Body).IsEqualTo(body);
        await Assert.That(subject.IsUndefined).IsFalse();
        await Assert.That(subject.Operator).IsEqualTo(Binary.Type.Multiply);
        await Assert.That(subject.Scope).IsEqualTo(Scope.Private);
    }
}