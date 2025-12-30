namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using System;
using MooVC.Syntax.CSharp;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    [Fact]
    public void GivenOptionsNotProvidedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Interface subject = InterfaceTestsData.Create();

        // Act
        Func<string> action = () => subject.ToSnippet(options: default);

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
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

        Snippet expected = """
            internal partial interface Sample
            {
                public event Created;

                public string ValueA { get; set; }

                public int ValueB { get; }

                public int this[string item] { get; }

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
        var result = subject.ToSnippet(Snippet.Options.Default);

        // Assert
        result.ShouldBeEquivalentTo(expected);
    }
}