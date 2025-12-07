namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Members.ParameterTests;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenIndexerIsUndefined()
    {
        // Act
        var subject = new Indexer();

        // Assert
        subject.IsUndefined.ShouldBeTrue();
        subject.Parameter.ShouldBe(Parameter.Undefined);
        subject.Result.ShouldBe(Result.Void);
        subject.Scope.ShouldBe(Scope.Public);
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Parameter parameter = ParameterTestsData.Create();
        Result result = new Result
        {
            Mode = Result.Modality.Synchronous,
            Type = typeof(string),
        };

        // Act
        var subject = new Indexer
        {
            Parameter = parameter,
            Result = result,
            Scope = Scope.Private,
        };

        // Assert
        subject.IsUndefined.ShouldBeFalse();
        subject.Parameter.ShouldBe(parameter);
        subject.Result.ShouldBe(result);
        subject.Scope.ShouldBe(Scope.Private);
    }
}
