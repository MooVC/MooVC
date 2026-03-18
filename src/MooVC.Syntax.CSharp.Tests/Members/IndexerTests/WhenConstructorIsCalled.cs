namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    private const string ParameterName = "index";
    private const string ParameterType = "int";
    private const string ResultType = "string";

    [Test]
    public async Task GivenDefaultsThenIndexerIsUndefined()
    {
        // Act
        var subject = new Indexer();

        // Assert
        await Assert.That(subject.Behaviours).IsEqualTo(Indexer.Methods.Default);
        await Assert.That(subject.IsUndefined).IsTrue();
        await Assert.That(subject.Parameter).IsEqualTo(Parameter.Undefined);
        await Assert.That(subject.Result).IsEqualTo(Result.Void);
        await Assert.That(subject.Scope).IsEqualTo(Scope.Public);
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var behaviours = new Indexer.Methods
        {
            Get = Snippet.From("value"),
            Set = Snippet.From("value = input"),
        };

        // Act
        var subject = new Indexer
        {
            Behaviours = behaviours,
            Parameter = new Parameter
            {
                Name = ParameterName,
                Type = new Symbol { Name = ParameterType },
            },
            Result = new Result
            {
                Mode = Result.Modality.Synchronous,
                Type = new Symbol { Name = ResultType },
            },
            Scope = Scope.Private,
        };

        // Assert
        await Assert.That(subject.Behaviours).IsEqualTo(behaviours);
        await Assert.That(subject.IsUndefined).IsFalse();

        await Assert.That(subject.Parameter).IsEqualTo(new Parameter
        {
            Name = ParameterName,
            Type = new Symbol { Name = ParameterType },
        });

        await Assert.That(subject.Result).IsEqualTo(new Result
        {
            Mode = Result.Modality.Synchronous,
            Type = new Symbol { Name = ResultType },
        });

        await Assert.That(subject.Scope).IsEqualTo(Scope.Private);
    }
}