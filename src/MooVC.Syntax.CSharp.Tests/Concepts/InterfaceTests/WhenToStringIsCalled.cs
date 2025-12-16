namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using System;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedInterfaceThenReturnsEmpty()
    {
        // Arrange
        Interface subject = Interface.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenOptionsNotProvidedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Interface subject = InterfaceTestsData.Create();

        // Act
        Func<string> action = () => subject.ToString(options: default);

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenValuesThenReturnsInterfaceSignature()
    {
        // Arrange
        var @event = new Event { Name = new Identifier("Created") };
        var property = new Property { Name = new Identifier("Value"), Type = typeof(string) };
        var method = new Method { Name = new Identifier("Execute") };

        Interface subject = InterfaceTestsData.Create(
            events: [@event],
            indexers: [new Indexer { Parameter = new Parameter { Name = new Identifier("item"), Type = typeof(string) } }],
            isPartial: true,
            methods: [method],
            name: new Declaration { Name = new Identifier(InterfaceTestsData.DefaultName) },
            properties: [property],
            scope: Scope.Internal);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldContain("internal partial interface");
        result.ShouldContain(InterfaceTestsData.DefaultName);
        result.ShouldContain(@event.Name.Name);
        result.ShouldContain("this");
        result.ShouldContain(property.Name.Name);
        result.ShouldContain(method.Name.Name);
    }
}
