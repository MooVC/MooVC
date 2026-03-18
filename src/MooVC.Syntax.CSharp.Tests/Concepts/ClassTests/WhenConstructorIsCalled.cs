namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Operators;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    private const string AttributeName = "Serializable";

    [Test]
    public async Task GivenDefaultsThenClassIsUndefined()
    {
        // Act
        var subject = new Class();

        // Assert
        _ = await Assert.That(subject.Attributes).IsEmpty();
        _ = await Assert.That(subject.Constructors).IsEmpty();
        _ = await Assert.That(subject.Events).IsEmpty();
        _ = await Assert.That(subject.Extensibility).IsEqualTo(Extensibility.Sealed);
        _ = await Assert.That(subject.Fields).IsEmpty();
        _ = await Assert.That(subject.Indexers).IsEmpty();
        _ = await Assert.That(subject.IsPartial).IsTrue();
        _ = await Assert.That(subject.IsStatic).IsFalse();
        _ = await Assert.That(subject.Methods).IsEmpty();
        _ = await Assert.That(subject.Declaration).IsEqualTo(Declaration.Unspecified);
        _ = await Assert.That(subject.Operators).IsEqualTo(new Operators());
        _ = await Assert.That(subject.Parameters).IsEmpty();
        _ = await Assert.That(subject.Properties).IsEmpty();
        _ = await Assert.That(subject.Scope).IsEqualTo(Scope.Public);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var attribute = new Attribute { Name = new Symbol { Name = AttributeName } };
        var constructor = new Constructor();
        var @event = new Event { Name = new Name("Created") };
        var field = new Field { Name = new Variable("_value"), Type = typeof(int) };
        var indexer = new Indexer { Parameter = new Parameter { Name = "Item" } };
        var method = new Method { Name = new Declaration { Name = "Execute" } };
        var property = new Property { Name = new Name("Value"), Type = typeof(string) };

        // Act
        Class subject = ClassTestsData.Create(
            attributes: [attribute],
            constructors: [constructor],
            events: [@event],
            extensibility: Extensibility.Abstract,
            fields: [field],
            indexers: [indexer],
            isPartial: true,
            isStatic: true,
            methods: [method],
            name: new Declaration { Name = ClassTestsData.DefaultName },
            operators: new Operators { Conversions = [new Conversion { Target = Symbol.Undefined }] },
            parameters: [new Parameter { Name = new Variable("input"), Type = typeof(string) }],
            properties: [property],
            scope: Scope.Internal);

        // Assert
        _ = await Assert.That(subject.Attributes).IsEqualTo(new[] { attribute });
        _ = await Assert.That(subject.Constructors).IsEqualTo(new[] { constructor });
        _ = await Assert.That(subject.Events).IsEqualTo(new[] { @event });
        _ = await Assert.That(subject.Extensibility).IsEqualTo(Extensibility.Abstract);
        _ = await Assert.That(subject.Fields).IsEqualTo(new[] { field });
        _ = await Assert.That(subject.Indexers).IsEqualTo(new[] { indexer });
        _ = await Assert.That(subject.IsPartial).IsTrue();
        _ = await Assert.That(subject.IsStatic).IsTrue();
        _ = await Assert.That(subject.Methods).IsEqualTo(new[] { method });
        _ = await Assert.That(subject.Declaration).IsEqualTo(new Declaration { Name = ClassTestsData.DefaultName });
        _ = await Assert.That(subject.Operators.Conversions).IsNotEmpty();
        _ = await subject.Parameters.Single();
        _ = await Assert.That(subject.Properties).IsEqualTo(new[] { property });
        _ = await Assert.That(subject.Scope).IsEqualTo(Scope.Internal);
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}