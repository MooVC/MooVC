namespace MooVC.Syntax.CSharp.Members.MethodTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

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
        subject.Parameters.ShouldBe([]);
        subject.Result.ShouldBe(Result.Task);
        subject.Scope.ShouldBe(Scope.Public);
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
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
            Body = body,
            Name = new Declaration { Name = MethodTestsData.DefaultName },
            Parameters = parameters,
            Result = result,
            Scope = Scope.Internal,
        };

        // Assert
        subject.Body.ShouldBe(body);
        subject.IsUndefined.ShouldBeFalse();
        subject.Name.ShouldBe(new Declaration { Name = MethodTestsData.DefaultName });
        subject.Parameters.ShouldBe(parameters);
        subject.Result.ShouldBe(result);
        subject.Scope.ShouldBe(Scope.Internal);
    }
}