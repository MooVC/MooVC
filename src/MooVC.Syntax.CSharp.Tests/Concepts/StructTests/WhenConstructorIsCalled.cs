namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Operators;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    private const string AttributeName = "Serializable";

    [Fact]
    public void GivenDefaultsThenStructIsUndefined()
    {
        // Act
        var subject = new Struct();

        // Assert
        subject.Attributes.ShouldBe([]);
        subject.Constructors.ShouldBe([]);
        subject.Events.ShouldBe([]);
        subject.Fields.ShouldBe([]);
        subject.Indexers.ShouldBe([]);
        subject.Behavior.ShouldBe(Struct.Kind.Default);
        subject.IsPartial.ShouldBeTrue();
        subject.Methods.ShouldBe([]);
        subject.Declaration.ShouldBe(Declaration.Unspecified);
        subject.Operators.ShouldBe(new Operators());
        subject.Parameters.ShouldBe([]);
        subject.Properties.ShouldBe([]);
        subject.Scope.ShouldBe(Scope.Public);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
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
        subject.Attributes.ShouldBe(new[] { attribute });
        subject.Constructors.ShouldBe(new[] { constructor });
        subject.Events.ShouldBe(new[] { @event });
        subject.Fields.ShouldBe(new[] { field });
        subject.Indexers.ShouldBe(new[] { indexer });
        subject.Behavior.ShouldBe(Struct.Kind.ReadOnly);
        subject.IsPartial.ShouldBeTrue();
        subject.Methods.ShouldBe(new[] { method });
        subject.Declaration.ShouldBe(new Declaration { Name = StructTestsData.DefaultName });
        subject.Operators.Conversions.ShouldNotBeEmpty();
        _ = subject.Parameters.ShouldHaveSingleItem();
        subject.Properties.ShouldBe(new[] { property });
        subject.Scope.ShouldBe(Scope.Internal);
        subject.IsUndefined.ShouldBeFalse();
    }
}