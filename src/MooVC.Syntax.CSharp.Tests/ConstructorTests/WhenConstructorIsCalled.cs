namespace MooVC.Syntax.CSharp.ConstructorTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.ParameterTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenConstructorIsUndefined()
    {
        // Act
        var subject = new Constructor();

        // Assert
        _ = await Assert.That(subject.Body).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Extensibility).IsEqualTo(Extensibility.Implicit);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
        _ = await Assert.That(subject.Parameters).IsEmpty();
        _ = await Assert.That(subject.Scope).IsEqualTo(Scopes.Public);
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var parameters = ImmutableArray.Create(ParameterTestsData.Create());
        const string body = "Initialize();";

        // Act
        var subject = new Constructor
        {
            Body = Snippet.From(body),
            Extensibility = Extensibility.Static,
            Parameters = parameters,
            Scope = Scopes.Internal,
        };

        // Assert
        _ = await Assert.That(subject.Body).IsEqualTo(Snippet.From(body));
        _ = await Assert.That(subject.Extensibility).IsEqualTo(Extensibility.Static);
        _ = await Assert.That(subject.IsUndefined).IsFalse();
        _ = await Assert.That(subject.Parameters).IsEqualTo(parameters);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scopes.Internal);
    }
}