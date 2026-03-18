namespace MooVC.Syntax.CSharp.Operators.BinaryTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public void GivenDefaultsThenBinaryIsUndefined()
    {
        // Act
        var subject = new Binary();

        // Assert
        subject.Body.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
        subject.Operator.ShouldBe(Binary.Type.Unspecified);
        subject.Scope.ShouldBe(Scope.Public);
    }

    [Test]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var body = Snippet.From(BinaryTestsData.DefaultBody);

        // Act
        var subject = new Binary
        {
            Body = body,
            Operator = Binary.Type.Multiply,
            Scope = Scope.Private,
        };

        // Assert
        subject.Body.ShouldBe(body);
        subject.IsUndefined.ShouldBeFalse();
        subject.Operator.ShouldBe(Binary.Type.Multiply);
        subject.Scope.ShouldBe(Scope.Private);
    }
}