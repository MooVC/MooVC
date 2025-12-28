namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenUnaryIsUndefined()
    {
        // Act
        var subject = new Unary();

        // Assert
        subject.Body.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
        subject.Operator.ShouldBe(Unary.Type.Unspecified);
        subject.Scope.ShouldBe(Scope.Public);
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var body = Snippet.From(UnaryTestsData.DefaultBody);

        // Act
        var subject = new Unary
        {
            Body = body,
            Operator = Unary.Type.Not,
            Scope = Scope.Private,
        };

        // Assert
        subject.Body.ShouldBe(body);
        subject.IsUndefined.ShouldBeFalse();
        subject.Operator.ShouldBe(Unary.Type.Not);
        subject.Scope.ShouldBe(Scope.Private);
    }
}