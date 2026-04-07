namespace MooVC.Syntax.CSharp.ConversionTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenConversionIsUndefined()
    {
        // Act
        var subject = new Conversion();

        // Assert
        _ = await Assert.That(subject.Body).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Direction).IsEqualTo(Conversion.Intents.To);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
        _ = await Assert.That(subject.Mode).IsEqualTo(Conversion.Types.Implicit);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scopes.Public);
        _ = await Assert.That(subject.Target).IsEqualTo(Symbol.Undefined);
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var body = Snippet.From(ConversionTestsData.DefaultBody);
        var subjectSymbol = new Symbol { Name = ConversionTestsData.DefaultSubject };

        // Act
        var subject = new Conversion
        {
            Body = body,
            Direction = Conversion.Intents.From,
            Mode = Conversion.Types.Explicit,
            Scope = Scopes.Private,
            Target = subjectSymbol,
        };

        // Assert
        _ = await Assert.That(subject.Body).IsEqualTo(body);
        _ = await Assert.That(subject.Direction).IsEqualTo(Conversion.Intents.From);
        _ = await Assert.That(subject.IsUndefined).IsFalse();
        _ = await Assert.That(subject.Mode).IsEqualTo(Conversion.Types.Explicit);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scopes.Private);
        _ = await Assert.That(subject.Target).IsEqualTo(subjectSymbol);
    }
}