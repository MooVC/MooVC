namespace MooVC.Syntax.CSharp.ClassTests;

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
        _ = await Assert.That(subject.Scope).IsEqualTo(Scopes.Public);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var attribute = new Attribute { Name = new() { Name = AttributeName } };
        var constructor = new Constructor();
        var @event = new Event { Name = new("Created") };
        var field = new Field { Name = new("_value"), Type = typeof(int) };
        var indexer = new Indexer { Parameter = new() { Name = "Item" } };
        var method = new Method { Name = new() { Name = "Execute" } };
        var property = new Property { Name = new("Value"), Type = typeof(string) };

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
            operators: new Operators { Conversions = [new() { Target = Symbol.Undefined }] },
            parameters: [new Parameter { Name = new("input"), Type = typeof(string) }],
            properties: [property],
            scope: Scopes.Internal);

        // Assert
        _ = await Assert.That(subject.Attributes).IsEquivalentTo([attribute]);
        _ = await Assert.That(subject.Constructors).IsEquivalentTo([constructor]);
        _ = await Assert.That(subject.Events).IsEquivalentTo([@event]);
        _ = await Assert.That(subject.Extensibility).IsEqualTo(Extensibility.Abstract);
        _ = await Assert.That(subject.Fields).IsEquivalentTo([field]);
        _ = await Assert.That(subject.Indexers).IsEquivalentTo([indexer]);
        _ = await Assert.That(subject.IsPartial).IsTrue();
        _ = await Assert.That(subject.IsStatic).IsTrue();
        _ = await Assert.That(subject.Methods).IsEquivalentTo([method]);
        _ = await Assert.That(subject.Declaration).IsEqualTo(new Declaration { Name = ClassTestsData.DefaultName });
        _ = await Assert.That(subject.Operators.Conversions).IsNotEmpty();
        _ = await Assert.That(subject.Parameters).HasSingleItem();
        _ = await Assert.That(subject.Properties).IsEquivalentTo([property]);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scopes.Internal);
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}