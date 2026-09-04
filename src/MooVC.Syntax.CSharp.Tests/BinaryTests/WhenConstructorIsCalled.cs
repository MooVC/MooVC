namespace MooVC.Syntax.CSharp.BinaryTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenBinaryIsUndefined()
    {
        // Act
        var subject = new Binary();

        // Assert
        _ = await Assert.That(subject.Body).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
        _ = await Assert.That(subject.Operator).IsEqualTo(Binary.Types.Unspecified);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scopes.Public);
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
            Operator = Binary.Types.Multiply,
            Scope = Scopes.Private,
        };

        // Assert
        _ = await Assert.That(subject.Body).IsEqualTo(body);
        _ = await Assert.That(subject.IsUndefined).IsFalse();
        _ = await Assert.That(subject.Operator).IsEqualTo(Binary.Types.Multiply);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scopes.Private);
    }
}