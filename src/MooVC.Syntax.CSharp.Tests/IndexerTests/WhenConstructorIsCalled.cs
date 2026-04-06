namespace MooVC.Syntax.CSharp.IndexerTests;

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
        _ = await Assert.That(subject.Behaviours).IsEqualTo(Indexer.Methods.Default);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
        _ = await Assert.That(subject.Parameter).IsEqualTo(Parameter.Undefined);
        _ = await Assert.That(subject.Result).IsEqualTo(Result.Void);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scope.Public);
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
            Parameter = new()
            {
                Name = ParameterName,
                Type = new() { Name = ParameterType },
            },
            Result = new()
            {
                Mode = Result.Modality.Synchronous,
                Type = new() { Name = ResultType },
            },
            Scope = Scope.Private,
        };

        // Assert
        _ = await Assert.That(subject.Behaviours).IsEqualTo(behaviours);
        _ = await Assert.That(subject.IsUndefined).IsFalse();

        _ = await Assert.That(subject.Parameter).IsEqualTo(new Parameter
        {
            Name = ParameterName,
            Type = new() { Name = ParameterType },
        });

        _ = await Assert.That(subject.Result).IsEqualTo(new Result
        {
            Mode = Result.Modality.Synchronous,
            Type = new() { Name = ResultType },
        });

        _ = await Assert.That(subject.Scope).IsEqualTo(Scope.Private);
    }
}