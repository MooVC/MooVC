namespace MooVC.Syntax.CSharp.Elements.Chaining.ParameterChainingChainTests;

using System.Collections.Immutable;

public sealed class WhenChainIsCalled
{
    private const string Value = "public Task ExecuteAsync(Order order, Customer customer, DateTime timestamp, CancellationToken cancellationToken)";

    [Fact]
    public void GivenMethodSignatureWhenLineIsLongThenEachParameterIsOnNewLine()
    {
        // Arrange
        var subject = new ParameterChainingChain();

        // Act
        ImmutableArray<string> result = subject.Chain(Value, 20);

        // Assert
        result.ShouldBe(
        [
            "public Task ExecuteAsync(",
            "    Order order,",
            "    Customer customer,",
            "    DateTime timestamp,",
            "    CancellationToken cancellationToken",
            ")",
        ]);
    }
}
