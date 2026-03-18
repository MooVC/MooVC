namespace MooVC.Syntax.Elements.SnippetTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements.Chaining;

public sealed class WhenChainIsCalled
{
    [Test]
    public async Task GivenSingleQueryWhenLineIsLongThenSplitsByDots()
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
        _ = await Assert.That(result.Length).IsEqualTo(expected.Length);
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenNestedQueriesWhenLineIsLongThenBothQueriesSplitsByDots()
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
            "        .Where(feature => feature.IsDefined)",
            "        .Select(feature => feature.Name))",
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
        _ = await Assert.That(result.Length).IsEqualTo(expected.Length);
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenParameterizedWhenLineIsLongThenOutterQuerySplitsByDots()
    {
        // Arrange
        const string value = "public Task Execute(Order order, Customer customer, DateTime timestamp, CancellationToken cancellationToken);";

        string[] expected =
        [
            "public Task Execute(",
            "    Order order,",
            "    Customer customer,",
            "    DateTime timestamp,",
            "    CancellationToken cancellationToken);",
        ];

        Snippet.Options options = Snippet.Options.Default
            .WithChaining(new[] { Parentheses.Instance })
            .WithMaxLength(20);

        var subject = Snippet.From(value);

        // Act
        ImmutableArray<string> result = subject.Chain(options);

        // Assert
        _ = await Assert.That(result.Length).IsEqualTo(expected.Length);
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenNestedParameterizedCallWhenLineIsLongThenOutterQuerySplitsByDots()
    {
        // Arrange
        const string value = "await instance.Execute(order, GetCustomerById(customerId, cancellationToken), timestamp, cancellationToken);";

        string[] expected =
        [
            "await instance.Execute(",
            "    order,",
            "    GetCustomerById(",
            "        customerId,",
            "        cancellationToken),",
            "    timestamp,",
            "    cancellationToken);",
        ];

        Snippet.Options options = Snippet.Options.Default
            .WithChaining(new[] { Parentheses.Instance })
            .WithMaxLength(20);

        var subject = Snippet.From(value);

        // Act
        ImmutableArray<string> result = subject.Chain(options);

        // Assert
        _ = await Assert.That(result.Length).IsEqualTo(expected.Length);
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenParameterizedQueryWhenLineIsLongThenOutterQuerySplitsByDots()
    {
        // Arrange
        const string value = "var result = query" +
            ".Where(item => item.IsActive)" +
            ".OrderBy(item => item.Name)" +
            ".Select(item => Convert(item.Id, item.Name, item.TimeStamp))" +
            ".ToList();";

        string[] expected =
        [
            "var result = query",
            "    .Where(item => item.IsActive)",
            "    .OrderBy(item => item.Name)",
            "    .Select(item => Convert(",
            "        item.Id,",
            "        item.Name,",
            "        item.TimeStamp))",
            "    .ToList();",
        ];

        Snippet.Options options = Snippet.Options.Default
            .WithChaining(new[] { OneDotPerLine.Instance, Parentheses.Instance })
            .WithMaxLength(20);

        var subject = Snippet.From(value);

        // Act
        ImmutableArray<string> result = subject.Chain(options);

        // Assert
        _ = await Assert.That(result.Length).IsEqualTo(expected.Length);
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}