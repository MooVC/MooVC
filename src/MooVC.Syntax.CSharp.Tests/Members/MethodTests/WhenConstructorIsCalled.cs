namespace MooVC.Syntax.CSharp.Members.MethodTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

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
        _ = await Assert.That(subject.Scope).IsEqualTo(Scope.Public);
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        ImmutableArray<Parameter> parameters =
        [
            new Parameter
            {
                Name = new Identifier(MethodTestsData.DefaultParameterName),
                Type = new Symbol { Name = MethodTestsData.DefaultParameterType },
            },
            new Parameter
            {
                Name = new Identifier("other"),
                Type = new Symbol { Name = "bool" },
            },
        ];

        var result = new Result
        {
            Mode = Result.Modality.Synchronous,
            Type = new Symbol { Name = MethodTestsData.DefaultResultType },
        };

        const string body = "return value;";

        // Act
        var subject = new Method
        {
            Body = Snippet.From(body),
            Name = new Declaration { Name = MethodTestsData.DefaultName },
            Parameters = parameters,
            Result = result,
            Scope = Scope.Internal,
        };

        // Assert
        _ = await Assert.That(subject.Body).IsEqualTo(Snippet.From(body));
        _ = await Assert.That(subject.IsUndefined).IsFalse();
        _ = await Assert.That(subject.Name).IsEqualTo(new Declaration { Name = MethodTestsData.DefaultName });
        _ = await Assert.That(subject.Parameters).IsEqualTo(parameters);
        _ = await Assert.That(subject.Result).IsEqualTo(result);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scope.Internal);
    }
}