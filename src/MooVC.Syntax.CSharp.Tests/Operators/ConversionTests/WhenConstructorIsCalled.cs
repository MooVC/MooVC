namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenConversionIsUndefined()
    {
        // Act
        var subject = new Conversion();

        // Assert
        _ = await Assert.That(subject.Body).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Direction).IsEqualTo(Conversion.Intent.To);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
        _ = await Assert.That(subject.Mode).IsEqualTo(Conversion.Type.Implicit);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scope.Public);
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
            Direction = Conversion.Intent.From,
            Mode = Conversion.Type.Explicit,
            Scope = Scope.Private,
            Target = subjectSymbol,
        };

        // Assert
        _ = await Assert.That(subject.Body).IsEqualTo(body);
        _ = await Assert.That(subject.Direction).IsEqualTo(Conversion.Intent.From);
        _ = await Assert.That(subject.IsUndefined).IsFalse();
        _ = await Assert.That(subject.Mode).IsEqualTo(Conversion.Type.Explicit);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scope.Private);
        _ = await Assert.That(subject.Target).IsEqualTo(subjectSymbol);
    }
}