namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Operators;

public sealed class WhenConstructorIsCalled
{
    private const string AttributeName = "Serializable";

    [Fact]
    public void GivenDefaultsThenRecordIsUndefined()
    {
        // Act
        var subject = new Record();

        // Assert
        subject.Attributes.ShouldBe(ImmutableArray<Attribute>.Empty);
        subject.Constructors.ShouldBe(ImmutableArray<Constructor>.Empty);
        subject.Events.ShouldBe(ImmutableArray<Event>.Empty);
        subject.Extensibility.ShouldBe(Extensibility.Sealed);
        subject.Fields.ShouldBe(ImmutableArray<Field>.Empty);
        subject.Indexers.ShouldBe(ImmutableArray<Indexer>.Empty);
        subject.IsPartial.ShouldBeFalse();
        subject.Methods.ShouldBe(ImmutableArray<Method>.Empty);
        subject.Name.ShouldBe(Declaration.Unspecified);
        subject.Operators.ShouldBe(new Operators());
        subject.Parameters.ShouldBe(ImmutableArray<Parameter>.Empty);
        subject.Properties.ShouldBe(ImmutableArray<Property>.Empty);
        subject.Scope.ShouldBe(Scope.Public);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var attribute = new Attribute { Name = new Symbol { Name = new Identifier(AttributeName) } };
        var constructor = new Constructor { Name = new Declaration { Name = new Identifier(RecordTestsData.DefaultName) } };
        var @event = new Event { Name = new Identifier("Created") };
        var field = new Field { Name = new Identifier("_value"), Type = typeof(int) };
        var indexer = new Indexer { Name = new Identifier("Item") };
        var method = new Method { Name = new Identifier("Execute") };
        var property = new Property { Name = new Identifier("Value"), Type = typeof(string) };

        // Act
        Record subject = RecordTestsData.Create(
            attributes: [attribute],
            constructors: [constructor],
            events: [@event],
            extensibility: Extensibility.Abstract,
            fields: [field],
            indexers: [indexer],
            isPartial: true,
            methods: [method],
            name: new Declaration { Name = new Identifier(RecordTestsData.DefaultName) },
            operators: new Operators { Conversions = [new Conversion { Destination = Symbol.Undefined }] },
            parameters: [new Parameter { Name = new Identifier("input"), Type = typeof(string) }],
            properties: [property],
            scope: Scope.Internal);

        // Assert
        subject.Attributes.ShouldBe(new[] { attribute });
        subject.Constructors.ShouldBe(new[] { constructor });
        subject.Events.ShouldBe(new[] { @event });
        subject.Extensibility.ShouldBe(Extensibility.Abstract);
        subject.Fields.ShouldBe(new[] { field });
        subject.Indexers.ShouldBe(new[] { indexer });
        subject.IsPartial.ShouldBeTrue();
        subject.Methods.ShouldBe(new[] { method });
        subject.Name.ShouldBe(new Declaration { Name = new Identifier(RecordTestsData.DefaultName) });
        subject.Operators.Conversions.ShouldNotBeEmpty();
        subject.Parameters.ShouldHaveSingleItem();
        subject.Properties.ShouldBe(new[] { property });
        subject.Scope.ShouldBe(Scope.Internal);
        subject.IsUndefined.ShouldBeFalse();
    }
}
