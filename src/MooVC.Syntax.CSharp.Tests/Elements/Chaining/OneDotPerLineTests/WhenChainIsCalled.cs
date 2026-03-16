namespace MooVC.Syntax.CSharp.Elements.Chaining.OneDotPerLineTests;

using System.Collections.Immutable;
using MooVC.Syntax.Elements;

public sealed class WhenChainIsCalled
{
    [Fact]
    public void GivenFluentInvocationWhenLineIsLongThenSplitsByDots()
    {
        // Arrange
        const string value = "var result = query.Where(item => item.IsActive).OrderBy(item => item.Name).Select(item => item.Id).ToList();";

        string[] expected =
        [
            "var result = query",
            "    .Where(item => item.IsActive)",
            "    .OrderBy(item => item.Name)",
            "    .Select(item => item.Id)",
            "    .ToList();",
        ];

        var subject = new OneDotPerLine();
        Snippet.Options options = Snippet.Options.Default.WithMaxLength(20);

        // Act
        ImmutableArray<string> result = subject.Chain(value, options);

        // Assert
        result.Length.ShouldBe(expected.Length);
        result.ShouldBe(expected);
    }
}