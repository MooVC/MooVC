namespace MooVC.Syntax.CSharp.Members.EventExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members.EventTests;
using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Event> events = isDefault
            ? default
            : [];

        // Act
        var snippet = events.ToSnippet(Event.Options.Default);

        // Assert
        _ = await Assert.That(snippet).IsEqualTo(Snippet.Empty);
    }

    [Test]
    public async Task GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Event> events = [EventTestsData.Create()];
        Event.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = events.ToSnippet(options!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenValuesThenAnOrderedSnippetIsReturned()
    {
        // Arrange
        Event @public = EventTestsData.Create(name: "Alpha", behaviours: new Event.Methods { Add = Snippet.From("a+=1;") });

        Event @protected = EventTestsData.Create(
            name: "Beta",
            scope: Scope.Protected,
            behaviours: new Event.Methods { Remove = Snippet.From("b-=1;") });

        Event @virtual = EventTestsData.Create(name: "Gamma", behaviours: new Event.Methods { Remove = Snippet.From("g();") });

        @virtual.Extensibility = Extensibility.Virtual;

        ImmutableArray<Event> events =
        [
            @public,
            @protected,
            @virtual,
        ];

        const string expected = """
            public event Handler Alpha
            {
                add => a+=1;
                remove;
            }

            public virtual event Handler Gamma
            {
                add;
                remove => g();
            }

            protected event Handler Beta
            {
                add;
                remove => b-=1;
            }
            """;

        // Act
        var snippet = events.ToSnippet(Event.Options.Default);

        // Assert
        _ = await Assert.That(snippet.ToString()).IsEqualTo(expected);
    }
}