namespace MooVC.Syntax.CSharp.Elements.Chaining.OneDotPerLineTests;

using System.Collections.Immutable;
using MooVC.Syntax.Elements;

public sealed class WhenChainIsCalled
{
    [Test]
    public async Task GivenSingleLineChainWhenLineIsLongThenSplitsByDots()
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
        await Assert.That(result.Length).IsEqualTo(expected.Length);
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenPropertyAccessWhenLineIsLongThenDoesNotSplitByDots()
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
        await Assert.That(result.Length).IsEqualTo(expected.Length);
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenMultiLineChainWhenLineIsLongThenOutterQuerySplitsByDots()
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
        await Assert.That(result.Length).IsEqualTo(expected.Length);
        await Assert.That(result).IsEqualTo(expected);
    }
}