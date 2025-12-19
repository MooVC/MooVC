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
    public void GivenValuesThenReturnsInterfaceSignature()
    {
        // Arrange
        var created = new Event { Name = "Created" };
        var execute = new Method { Name = new Declaration { Name = "Execute" } };
        var indexer = new Indexer { Parameter = new Parameter { Name = "item", Type = typeof(string) }, Result = typeof(int) };
        var valueA = new Property { Name = "ValueA", Type = typeof(string) };

        var valueB = new Property
        {
            Behaviours = new Property.Methods { Set = new Property.Setter { Mode = Property.Mode.ReadOnly } },
            Name = "ValueB",
            Type = typeof(int),
        };

        const string expected = """
            internal partial interface Sample
            {
                public event Created;

                public string ValueA { get; set; }

                public int ValueB { get; }

                public int this[string item] { get; set; }

                public Task Execute();
            }
            """;

        Interface subject = InterfaceTestsData.Create(
            events: [created],
            indexers: [indexer],
            isPartial: true,
            methods: [execute],
            name: new Declaration { Name = InterfaceTestsData.DefaultName },
            properties: [valueA, valueB],
            scope: Scope.Internal);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}