namespace MooVC.Syntax.CSharp.Elements.Chaining.ArgumentChainingChainTests;

using System.Collections.Immutable;

public sealed class WhenChainIsCalled
{
    private const string Value = "var result = service.ExecuteAsync(request, cancellationToken, retryPolicy, logger);";

    [Fact]
    public void GivenInvocationArgumentsWhenLineIsLongThenEachArgumentIsOnNewLine()
    {
        // Arrange
        var subject = new ArgumentChainingChain();

        // Act
        ImmutableArray<string> result = subject.Chain(Value, 20);

        // Assert
        result.ShouldBe(
        [
            "var result = service.ExecuteAsync(",
            "    request,",
            "    cancellationToken,",
            "    retryPolicy,",
            "    logger",
            ");",
        ]);
    }
}
