namespace MooVC.Syntax.CSharp.InterfaceTests;

public sealed class WhenConstructorIsCalled
{
    private const string AttributeName = "Serializable";

    [Test]
    public async Task GivenDefaultsThenInterfaceIsUndefined()
    {
        // Act
        var subject = new Interface();

        // Assert
        _ = await Assert.That(subject.Attributes).IsEmpty();
        _ = await Assert.That(subject.Events).IsEmpty();
        _ = await Assert.That(subject.Indexers).IsEmpty();
        _ = await Assert.That(subject.IsPartial).IsTrue();
        _ = await Assert.That(subject.Methods).IsEmpty();
        _ = await Assert.That(subject.Declaration).IsEqualTo(Declaration.Unspecified);
        _ = await Assert.That(subject.Operators).IsEqualTo(new Operators());
        _ = await Assert.That(subject.Properties).IsEmpty();
        _ = await Assert.That(subject.Scope).IsEqualTo(Scope.Public);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var attribute = new Attribute { Name = new() { Name = AttributeName } };
        var @event = new Event { Name = new("Created") };
        var indexer = new Indexer { Parameter = new() { Name = "Item" } };
        var method = new Method { Name = new() { Name = "Execute" } };
        var property = new Property { Name = new("Value"), Type = typeof(string) };

        // Act
        Interface subject = InterfaceTestsData.Create(
            attributes: [attribute],
            events: [@event],
            indexers: [indexer],
            isPartial: true,
            methods: [method],
            name: new Declaration { Name = InterfaceTestsData.DefaultName },
            operators: new Operators { Conversions = [new() { Target = Symbol.Undefined }] },
            properties: [property],
            scope: Scope.Internal);

        // Assert
        _ = await Assert.That(subject.Attributes).IsEquivalentTo([attribute]);
        _ = await Assert.That(subject.Events).IsEquivalentTo([@event]);
        _ = await Assert.That(subject.Indexers).IsEquivalentTo([indexer]);
        _ = await Assert.That(subject.IsPartial).IsTrue();
        _ = await Assert.That(subject.Methods).IsEquivalentTo([method]);
        _ = await Assert.That(subject.Declaration).IsEqualTo(new Declaration { Name = InterfaceTestsData.DefaultName });
        _ = await Assert.That(subject.Operators.Conversions).IsNotEmpty();
        _ = await Assert.That(subject.Properties).IsEquivalentTo([property]);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scope.Internal);
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}