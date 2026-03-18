namespace MooVC.Syntax.CSharp.InterfaceTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenUndefinedInterfaceThenReturnsEmpty()
    {
        // Arrange
        Interface subject = Interface.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValuesThenReturnsInterfaceSignature()
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
                event Created;

                string ValueA { get; init; }

                int ValueB { get; }

                int this[string item] { get; }

                Task Execute();
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
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}