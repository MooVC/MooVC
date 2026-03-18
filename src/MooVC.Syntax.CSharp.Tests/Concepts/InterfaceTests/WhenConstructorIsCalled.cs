namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Operators;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    private const string AttributeName = "Serializable";

    [Test]
    public async Task GivenDefaultsThenInterfaceIsUndefined()
    {
        // Act
        var subject = new Interface();

        // Assert
        await Assert.That(subject.Attributes).IsEqualTo([]);
        await Assert.That(subject.Events).IsEqualTo([]);
        await Assert.That(subject.Indexers).IsEqualTo([]);
        await Assert.That(subject.IsPartial).IsTrue();
        await Assert.That(subject.Methods).IsEqualTo([]);
        await Assert.That(subject.Declaration).IsEqualTo(Declaration.Unspecified);
        await Assert.That(subject.Operators).IsEqualTo(new Operators());
        await Assert.That(subject.Properties).IsEqualTo([]);
        await Assert.That(subject.Scope).IsEqualTo(Scope.Public);
        await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var attribute = new Attribute { Name = new Symbol { Name = AttributeName } };
        var @event = new Event { Name = new Name("Created") };
        var indexer = new Indexer { Parameter = new Parameter { Name = "Item" } };
        var method = new Method { Name = new Declaration { Name = "Execute" } };
        var property = new Property { Name = new Name("Value"), Type = typeof(string) };

        // Act
        Interface subject = InterfaceTestsData.Create(
            attributes: [attribute],
            events: [@event],
            indexers: [indexer],
            isPartial: true,
            methods: [method],
            name: new Declaration { Name = InterfaceTestsData.DefaultName },
            operators: new Operators { Conversions = [new Conversion { Target = Symbol.Undefined }] },
            properties: [property],
            scope: Scope.Internal);

        // Assert
        await Assert.That(subject.Attributes).IsEqualTo(new[] { attribute });
        await Assert.That(subject.Events).IsEqualTo(new[] { @event });
        await Assert.That(subject.Indexers).IsEqualTo(new[] { indexer });
        await Assert.That(subject.IsPartial).IsTrue();
        await Assert.That(subject.Methods).IsEqualTo(new[] { method });
        await Assert.That(subject.Declaration).IsEqualTo(new Declaration { Name = InterfaceTestsData.DefaultName });
        await Assert.That(subject.Operators.Conversions).IsNotEmpty();
        await Assert.That(subject.Properties).IsEqualTo(new[] { property });
        await Assert.That(subject.Scope).IsEqualTo(Scope.Internal);
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}