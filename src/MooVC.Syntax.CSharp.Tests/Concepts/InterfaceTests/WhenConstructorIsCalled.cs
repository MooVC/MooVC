namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Operators;

public sealed class WhenConstructorIsCalled
{
    private const string AttributeName = "Serializable";

    [Fact]
    public void GivenDefaultsThenInterfaceIsUndefined()
    {
        // Act
        var subject = new Interface();

        // Assert
        subject.Attributes.ShouldBe([]);
        subject.Events.ShouldBe([]);
        subject.Indexers.ShouldBe([]);
        subject.IsPartial.ShouldBeFalse();
        subject.Methods.ShouldBe([]);
        subject.Name.ShouldBe(Declaration.Unspecified);
        subject.Operators.ShouldBe(new Operators());
        subject.Properties.ShouldBe([]);
        subject.Scope.ShouldBe(Scope.Public);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var attribute = new Attribute { Name = new Symbol { Name = new Identifier(AttributeName) } };
        var @event = new Event { Name = new Identifier("Created") };
        var indexer = new Indexer { Parameter = new Parameter { Name = "Item" } };
        var method = new Method { Name = new Declaration { Name = "Execute" } };
        var property = new Property { Name = new Identifier("Value"), Type = typeof(string) };

        // Act
        Interface subject = InterfaceTestsData.Create(
            attributes: [attribute],
            events: [@event],
            indexers: [indexer],
            isPartial: true,
            methods: [method],
            name: new Declaration { Name = new Identifier(InterfaceTestsData.DefaultName) },
            operators: new Operators { Conversions = [new Conversion { Subject = Symbol.Undefined }] },
            properties: [property],
            scope: Scope.Internal);

        // Assert
        subject.Attributes.ShouldBe(new[] { attribute });
        subject.Events.ShouldBe(new[] { @event });
        subject.Indexers.ShouldBe(new[] { indexer });
        subject.IsPartial.ShouldBeTrue();
        subject.Methods.ShouldBe(new[] { method });
        subject.Name.ShouldBe(new Declaration { Name = new Identifier(InterfaceTestsData.DefaultName) });
        subject.Operators.Conversions.ShouldNotBeEmpty();
        subject.Properties.ShouldBe(new[] { property });
        subject.Scope.ShouldBe(Scope.Internal);
        subject.IsUndefined.ShouldBeFalse();
    }
}