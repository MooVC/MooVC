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
        _ = await Assert.That(subject.Default).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.IsReadOnly).IsTrue();
        _ = await Assert.That(subject.IsStatic).IsFalse();
        _ = await Assert.That(subject.IsUndefined).IsTrue();
        _ = await Assert.That(subject.Name).IsEqualTo(Variable.Unnamed);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scope.Private);
        _ = await Assert.That(subject.Type).IsEqualTo(Symbol.Undefined);
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
        _ = await Assert.That(subject.Default).IsEqualTo(@default);
        _ = await Assert.That(subject.IsReadOnly).IsFalse();
        _ = await Assert.That(subject.IsStatic).IsTrue();
        _ = await Assert.That(subject.IsUndefined).IsFalse();
        _ = await Assert.That(subject.Name).IsEqualTo(new Variable(FieldTestsData.DefaultName));
        _ = await Assert.That(subject.Scope).IsEqualTo(Scope.Internal);
        _ = await Assert.That(subject.Type).IsEqualTo(type);
    }
}