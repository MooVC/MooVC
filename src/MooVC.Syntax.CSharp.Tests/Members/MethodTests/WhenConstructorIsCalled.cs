namespace MooVC.Syntax.CSharp.Members.MethodTests;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenMethodIsUndefined()
    {
        // Act
        var subject = new Method();

        // Assert
        subject.Body.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
        subject.Name.ShouldBe(Declaration.Unspecified);
        subject.Parameters.ShouldBe(ImmutableArray<Parameter>.Empty);
        subject.Result.ShouldBe(Result.Task);
        subject.Scope.ShouldBe(Scope.Public);
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var parameters = new[]
        {
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
        }.ToImmutableArray();

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
            Name = new Declaration { Name = new Identifier(MethodTestsData.DefaultName) },
            Parameters = parameters,
            Result = result,
            Scope = Scope.Internal,
        };

        // Assert
        subject.Body.ShouldBe(Snippet.From(body));
        subject.IsUndefined.ShouldBeFalse();
        subject.Name.ShouldBe(new Declaration { Name = new Identifier(MethodTestsData.DefaultName) });
        subject.Parameters.ShouldBe(parameters);
        subject.Result.ShouldBe(result);
        subject.Scope.ShouldBe(Scope.Internal);
    }
}
