namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenConversionIsUndefined()
    {
        // Act
        var subject = new Conversion();

        // Assert
        await Assert.That(subject.Body).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Direction).IsEqualTo(Conversion.Intent.To);
        await Assert.That(subject.IsUndefined).IsTrue();
        await Assert.That(subject.Mode).IsEqualTo(Conversion.Type.Implicit);
        await Assert.That(subject.Scope).IsEqualTo(Scope.Public);
        await Assert.That(subject.Target).IsEqualTo(Symbol.Undefined);
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
        await Assert.That(subject.Body).IsEqualTo(body);
        await Assert.That(subject.Direction).IsEqualTo(Conversion.Intent.From);
        await Assert.That(subject.IsUndefined).IsFalse();
        await Assert.That(subject.Mode).IsEqualTo(Conversion.Type.Explicit);
        await Assert.That(subject.Scope).IsEqualTo(Scope.Private);
        await Assert.That(subject.Target).IsEqualTo(subjectSymbol);
    }
}