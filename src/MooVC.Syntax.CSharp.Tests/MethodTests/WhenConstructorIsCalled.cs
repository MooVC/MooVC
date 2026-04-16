namespace MooVC.Syntax.CSharp.MethodTests;

using System.Collections.Immutable;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenMethodIsUndefined()
    {
        // Act
        var subject = new Method();

        // Assert
        _ = await Assert.That(subject.Body).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
        _ = await Assert.That(subject.Name).IsEqualTo(Declaration.Unspecified);
        _ = await Assert.That(subject.Parameters).IsEmpty();
        _ = await Assert.That(subject.Result).IsEqualTo(Result.Task);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scopes.Public);
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        ImmutableArray<Parameter> parameters =
        [
            new Parameter
            {
                Name = new(MethodTestsData.DefaultParameterName),
                Type = new() { Name = MethodTestsData.DefaultParameterType },
            },
            new Parameter
            {
                Name = new("other"),
                Type = new() { Name = "bool" },
            },
        ];

        var result = new Result
        {
            Mode = Result.Modes.Synchronous,
            Type = new() { Name = MethodTestsData.DefaultResultType },
        };

        const string body = "return value;";

        // Act
        var subject = new Method
        {
            Body = Snippet.From(body),
            Name = new() { Name = MethodTestsData.DefaultName },
            Parameters = parameters,
            Result = result,
            Scope = Scopes.Internal,
        };

        // Assert
        _ = await Assert.That(subject.Body).IsEqualTo(Snippet.From(body));
        _ = await Assert.That(subject.IsUndefined).IsFalse();
        _ = await Assert.That(subject.Name).IsEqualTo(new Declaration { Name = MethodTestsData.DefaultName });
        _ = await Assert.That(subject.Parameters).IsEqualTo(parameters);
        _ = await Assert.That(subject.Result).IsEqualTo(result);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scopes.Internal);
    }
}