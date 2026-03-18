namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Operators;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    private const string AttributeName = "Serializable";

    [Test]
    public async Task GivenDefaultsThenStructIsUndefined()
    {
        // Act
        var subject = new Struct();

        // Assert
        await Assert.That(subject.Attributes).IsEqualTo([]);
        await Assert.That(subject.Constructors).IsEqualTo([]);
        await Assert.That(subject.Events).IsEqualTo([]);
        await Assert.That(subject.Fields).IsEqualTo([]);
        await Assert.That(subject.Indexers).IsEqualTo([]);
        await Assert.That(subject.Behavior).IsEqualTo(Struct.Kind.Default);
        await Assert.That(subject.IsPartial).IsTrue();
        await Assert.That(subject.Methods).IsEqualTo([]);
        await Assert.That(subject.Declaration).IsEqualTo(Declaration.Unspecified);
        await Assert.That(subject.Operators).IsEqualTo(new Operators());
        await Assert.That(subject.Parameters).IsEqualTo([]);
        await Assert.That(subject.Properties).IsEqualTo([]);
        await Assert.That(subject.Scope).IsEqualTo(Scope.Public);
        await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var attribute = new Attribute { Name = new Symbol { Name = AttributeName } };
        var constructor = new Constructor { Scope = Scope.Private };
        var @event = new Event { Name = new Name("Created") };
        var field = new Field { Name = new Variable("_value"), Type = typeof(int) };
        var indexer = new Indexer { Parameter = new Parameter { Name = "Item" } };
        var method = new Method { Name = new Declaration { Name = "Execute" } };
        var property = new Property { Name = new Name("Value"), Type = typeof(string) };

        // Act
        Struct subject = StructTestsData.Create(
            attributes: [attribute],
            behavior: Struct.Kind.ReadOnly,
            constructors: [constructor],
            events: [@event],
            fields: [field],
            indexers: [indexer],
            isPartial: true,
            methods: [method],
            name: new Declaration { Name = StructTestsData.DefaultName },
            operators: new Operators { Conversions = [new Conversion { Target = Symbol.Undefined }] },
            parameters: [new Parameter { Name = new Variable("input"), Type = typeof(string) }],
            properties: [property],
            scope: Scope.Internal);

        // Assert
        await Assert.That(subject.Attributes).IsEqualTo(new[] { attribute });
        await Assert.That(subject.Constructors).IsEqualTo(new[] { constructor });
        await Assert.That(subject.Events).IsEqualTo(new[] { @event });
        await Assert.That(subject.Fields).IsEqualTo(new[] { field });
        await Assert.That(subject.Indexers).IsEqualTo(new[] { indexer });
        await Assert.That(subject.Behavior).IsEqualTo(Struct.Kind.ReadOnly);
        await Assert.That(subject.IsPartial).IsTrue();
        await Assert.That(subject.Methods).IsEqualTo(new[] { method });
        await Assert.That(subject.Declaration).IsEqualTo(new Declaration { Name = StructTestsData.DefaultName });
        await Assert.That(subject.Operators.Conversions).IsNotEmpty();
        _ = await subject.Parameters.Single();
        await Assert.That(subject.Properties).IsEqualTo(new[] { property });
        await Assert.That(subject.Scope).IsEqualTo(Scope.Internal);
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}