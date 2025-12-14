namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenConversionIsUndefined()
    {
        // Act
        var subject = new Conversion();

        // Assert
        subject.Body.ShouldBe(Snippet.Empty);
        subject.Direction.ShouldBe(Conversion.Intent.To);
        subject.IsUndefined.ShouldBeTrue();
        subject.Mode.ShouldBe(Conversion.Type.Implicit);
        subject.Scope.ShouldBe(Scope.Public);
        subject.Subject.ShouldBe(Symbol.Undefined);
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var body = Snippet.From(ConversionTestsData.DefaultBody);
        var subjectSymbol = new Symbol { Name = ConversionTestsData.DefaultSubject };

        // Act
        var subject = new Conversion
        {
            Body = body,
            Direction = Conversion.Intent.From,
            Mode = Conversion.Type.Explicit,
            Scope = Scope.Private,
            Subject = subjectSymbol,
        };

        // Assert
        subject.Body.ShouldBe(body);
        subject.Direction.ShouldBe(Conversion.Intent.From);
        subject.IsUndefined.ShouldBeFalse();
        subject.Mode.ShouldBe(Conversion.Type.Explicit);
        subject.Scope.ShouldBe(Scope.Private);
        subject.Subject.ShouldBe(subjectSymbol);
    }
}