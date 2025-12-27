namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Members.ParameterTests;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenConstructorIsUndefined()
    {
        // Act
        var subject = new Constructor();

        // Assert
        subject.Body.ShouldBe(Snippet.Empty);
        subject.Extensibility.ShouldBe(Extensibility.Implicit);
        subject.IsUndefined.ShouldBeTrue();
        subject.Parameters.ShouldBe(ImmutableArray<Parameter>.Empty);
        subject.Scope.ShouldBe(Scope.Public);
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
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
        subject.Body.ShouldBe(Snippet.From(body));
        subject.Extensibility.ShouldBe(Extensibility.Static);
        subject.IsUndefined.ShouldBeFalse();
        subject.Parameters.ShouldBe(parameters);
        subject.Scope.ShouldBe(Scope.Internal);
    }
}
