namespace MooVC.Syntax.Elements.SnippetTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements.Chaining;

public sealed class WhenChainIsCalled
{
    [Fact]
    public void GivenSingleLineChainWhenLineIsLongThenSplitsByDots()
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

        Snippet.Options options = Snippet.Options.Default
            .WithChaining(new[] { OneDotPerLine.Instance })
            .WithMaxLength(20);

        var subject = Snippet.From(value);

        // Act
        ImmutableArray<string> result = subject.Chain(options);

        // Assert
        result.Length.ShouldBe(expected.Length);
        result.ShouldBe(expected);
    }

    [Fact]
    public void GivenMultiLineChainWhenLineIsLongThenOutterQuerySplitsByDots()
    {
        // Arrange
        const string value = "var result = query" +
            ".Where(unit => unit.IsDefined)" +
            ".OrderBy(unit => unit.Name)" +
            ".SelectMany(unit => unit.Features" +
                ".Where(feature => feature.IsDefined)" +
                ".Select(feature => feature.Name))" +
            ".Distinct()" +
            ".ToList();";

        string[] expected =
        [
            "var result = query",
            "    .Where(unit => unit.IsDefined)",
            "    .OrderBy(unit => unit.Name)",
            "    .SelectMany(unit => unit.Features",
            "         .Where(feature => feature.IsDefined)",
            "         .Select(feature => feature.Name))",
            "    .Distinct()",
            "    .ToList();",
        ];

        Snippet.Options options = Snippet.Options.Default
            .WithChaining(new[] { OneDotPerLine.Instance })
            .WithMaxLength(20);

        var subject = Snippet.From(value);

        // Act
        ImmutableArray<string> result = subject.Chain(options);

        // Assert
        result.Length.ShouldBe(expected.Length);
        result.ShouldBe(expected);
    }
}