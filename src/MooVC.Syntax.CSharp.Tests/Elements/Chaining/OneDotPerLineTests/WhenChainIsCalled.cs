namespace MooVC.Syntax.CSharp.Elements.Chaining.OneDotPerLineTests;

using System.Collections.Immutable;
using MooVC.Syntax.Elements;

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

        Snippet.IChain subject = OneDotPerLine.Instance;
        Snippet.Options options = Snippet.Options.Default.WithMaxLength(20);

        // Act
        ImmutableArray<string> result = subject.Chain(value, options);

        // Assert
        result.Length.ShouldBe(expected.Length);
        result.ShouldBe(expected);
    }

    [Fact]
    public void GivenPropertyAccessWhenLineIsLongThenDoesNotSplitByDots()
    {
        // Arrange
        const string value = "var result = source.Select(item => item.TimeStamp).ToList();";

        string[] expected =
        [
            "var result = source",
            "    .Select(item => item.TimeStamp)",
            "    .ToList();",
        ];

        Snippet.IChain subject = OneDotPerLine.Instance;
        Snippet.Options options = Snippet.Options.Default.WithMaxLength(20);

        // Act
        ImmutableArray<string> result = subject.Chain(value, options);

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
            "    .SelectMany(unit => unit.Features.Where(feature => feature.IsDefined).Select(feature => feature.Name))",
            "    .Distinct()",
            "    .ToList();",
        ];

        Snippet.IChain subject = OneDotPerLine.Instance;
        Snippet.Options options = Snippet.Options.Default.WithMaxLength(20);

        // Act
        ImmutableArray<string> result = subject.Chain(value, options);

        // Assert
        result.Length.ShouldBe(expected.Length);
        result.ShouldBe(expected);
    }
}