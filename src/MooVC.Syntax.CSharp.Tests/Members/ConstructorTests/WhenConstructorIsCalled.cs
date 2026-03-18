namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Elements.ParameterTests;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenConstructorIsUndefined()
    {
        // Act
        var subject = new Constructor();

        // Assert
        await Assert.That(subject.Body).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Extensibility).IsEqualTo(Extensibility.Implicit);
        await Assert.That(subject.IsUndefined).IsTrue();
        await Assert.That(subject.Parameters).IsEqualTo([]);
        await Assert.That(subject.Scope).IsEqualTo(Scope.Public);
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
            Scope = Scope.Internal,
        };

        // Assert
        await Assert.That(subject.Body).IsEqualTo(Snippet.From(body));
        await Assert.That(subject.Extensibility).IsEqualTo(Extensibility.Static);
        await Assert.That(subject.IsUndefined).IsFalse();
        await Assert.That(subject.Parameters).IsEqualTo(parameters);
        await Assert.That(subject.Scope).IsEqualTo(Scope.Internal);
    }
}