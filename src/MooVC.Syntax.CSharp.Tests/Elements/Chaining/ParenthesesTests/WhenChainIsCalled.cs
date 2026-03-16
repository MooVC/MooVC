namespace MooVC.Syntax.CSharp.Elements.Chaining.ParenthesesTests;

using System.Collections.Immutable;
using MooVC.Syntax.Elements;

public sealed class WhenChainIsCalled
{
    [Fact]
    public void GivenMethodSignatureWhenLineIsLongThenEachParameterIsOnNewLine()
    {
        // Arrange
        Snippet.IChain subject = Parentheses.Instance;
        Snippet.Options options = Snippet.Options.Default.WithMaxLength(20);

        const string value = "public Task Execute(Order order, Customer customer, DateTime timestamp, CancellationToken cancellationToken);";

        string[] expected =
        [
            "public Task Execute(",
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

    [Fact]
    public void GivenNestedMethodCallWhenLineIsLongThenOutterParenthesesIsChainedFirst()
    {
        // Arrange
        Snippet.IChain subject = Parentheses.Instance;
        Snippet.Options options = Snippet.Options.Default.WithMaxLength(20);

        const string value = "await instance.Execute(order, GetCustomerById(customerId, cancellationToken), timestamp, cancellationToken);";

        string[] expected =
        [
            "await instance.Execute(",
            "    order,",
            "    GetCustomerById(customerId, cancellationToken),",
            "    timestamp,",
            "    cancellationToken);",
        ];

        // Act
        ImmutableArray<string> result = subject.Chain(value, options);

        // Assert
        result.Length.ShouldBe(expected.Length);
        result.ShouldBe(expected);
    }
}