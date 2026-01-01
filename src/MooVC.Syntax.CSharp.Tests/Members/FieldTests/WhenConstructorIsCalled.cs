namespace MooVC.Syntax.CSharp.Members.FieldTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Elements.SymbolTests;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenFieldIsUndefined()
    {
        // Act
        var subject = new Field();

        // Assert
        subject.Default.ShouldBe(Snippet.Empty);
        subject.IsReadOnly.ShouldBeTrue();
        subject.IsStatic.ShouldBeFalse();
        subject.IsUndefined.ShouldBeTrue();
        subject.Name.ShouldBe(Variable.Unnamed);
        subject.Scope.ShouldBe(Scope.Public);
        subject.Type.ShouldBe(Symbol.Undefined);
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var @default = Snippet.From("default");
        Symbol type = SymbolTestsData.Create("Result");

        // Act
        var subject = new Field
        {
            Default = @default,
            IsReadOnly = false,
            IsStatic = true,
            Name = new Identifier(FieldTestsData.DefaultName),
            Scope = Scope.Internal,
            Type = type,
        };

        // Assert
        subject.Default.ShouldBe(@default);
        subject.IsReadOnly.ShouldBeFalse();
        subject.IsStatic.ShouldBeTrue();
        subject.IsUndefined.ShouldBeFalse();
        subject.Name.ShouldBe(new Variable(FieldTestsData.DefaultName));
        subject.Scope.ShouldBe(Scope.Internal);
        subject.Type.ShouldBe(type);
    }
}