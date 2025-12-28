namespace MooVC.Syntax.CSharp.Members.EventExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members.EventTests;

public sealed class WhenToSnippetIsCalled
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Event> events = isDefault
            ? default
            : [];

        // Act
        var snippet = events.ToSnippet(Snippet.Options.Default);

        // Assert
        snippet.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Event> events = [EventTestsData.Create()];
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = events.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenValuesThenAnOrderedSnippetIsReturned()
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
                add
                {
                    a+=1;
                }
                remove;
            }

            public virtual event Handler Gamma
            {
                add;
                remove
                {
                    g();
                }
            }

            protected event Handler Beta
            {
                add;
                remove
                {
                    b-=1;
                }
            }
            """;

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        // Act
        var snippet = events.ToSnippet(options);

        // Assert
        snippet.ToString().ShouldBe(expected);
    }
}