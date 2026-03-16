namespace MooVC.Syntax.CSharp.Elements.Chaining.ParenthesesTests;

using System.Collections.Immutable;
using Castle.Core.Resource;
using MooVC.Syntax.Attributes.Solution;
using MooVC.Syntax.Elements;

public sealed class WhenChainIsCalled
{
    [Fact]
    public void GivenMethodSignatureWhenLineIsLongThenEachParameterIsOnNewLine()
    {
        // Arrange
        var subject = new Parentheses();
        Snippet.Options options = Snippet.Options.Default.WithMaxLength(20);

        const string value = "public Task ExecuteAsync(Order order, Customer customer, DateTime timestamp, CancellationToken cancellationToken);";

        string[] expected =
        [
            "public Task ExecuteAsync(",
            "    Order order,",
            "    Customer customer,",
            "    DateTime timestamp,",
            "    CancellationToken cancellationToken);",
        ];

        // Act
        ImmutableArray<string> result = subject.Chain(value, options);

        // Assert
        result.Length.ShouldBe(expected.Length);
        result.ShouldBe(expected);
    }
}