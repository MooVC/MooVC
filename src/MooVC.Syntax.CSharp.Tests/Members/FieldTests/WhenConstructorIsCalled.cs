namespace MooVC.Syntax.CSharp.Members.FieldTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Elements.SymbolTests;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenFieldIsUndefined()
    {
        // Act
        var subject = new Field();

        // Assert
        await Assert.That(subject.Default).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.IsReadOnly).IsTrue();
        await Assert.That(subject.IsStatic).IsFalse();
        await Assert.That(subject.IsUndefined).IsTrue();
        await Assert.That(subject.Name).IsEqualTo(Variable.Unnamed);
        await Assert.That(subject.Scope).IsEqualTo(Scope.Private);
        await Assert.That(subject.Type).IsEqualTo(Symbol.Undefined);
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
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
        await Assert.That(subject.Default).IsEqualTo(@default);
        await Assert.That(subject.IsReadOnly).IsFalse();
        await Assert.That(subject.IsStatic).IsTrue();
        await Assert.That(subject.IsUndefined).IsFalse();
        await Assert.That(subject.Name).IsEqualTo(new Variable(FieldTestsData.DefaultName));
        await Assert.That(subject.Scope).IsEqualTo(Scope.Internal);
        await Assert.That(subject.Type).IsEqualTo(type);
    }
}