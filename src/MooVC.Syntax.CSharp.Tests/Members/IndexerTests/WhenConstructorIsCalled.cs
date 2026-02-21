namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    private const string ParameterName = "index";
    private const string ParameterType = "int";
    private const string ResultType = "string";

    [Fact]
    public void GivenDefaultsThenIndexerIsUndefined()
    {
        // Act
        var subject = new Indexer();

        // Assert
        subject.Behaviours.ShouldBe(Indexer.Methods.Default);
        subject.IsUndefined.ShouldBeTrue();
        subject.Parameter.ShouldBe(Parameter.Undefined);
        subject.Result.ShouldBe(Result.Void);
        subject.Scope.ShouldBe(Scope.Public);
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var behaviours = new Indexer.Methods
        {
            Get = "value",
            Set = "value = input",
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
        subject.Behaviours.ShouldBe(behaviours);
        subject.IsUndefined.ShouldBeFalse();

        subject.Parameter.ShouldBe(new Parameter
        {
            Name = ParameterName,
            Type = new Symbol { Name = ParameterType },
        });

        subject.Result.ShouldBe(new Result
        {
            Mode = Result.Modality.Synchronous,
            Type = new Symbol { Name = ResultType },
        });

        subject.Scope.ShouldBe(Scope.Private);
    }
}