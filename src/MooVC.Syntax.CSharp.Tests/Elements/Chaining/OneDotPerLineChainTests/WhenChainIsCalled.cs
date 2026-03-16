namespace MooVC.Syntax.CSharp.Elements.Chaining.OneDotPerLineChainTests;

using System.Collections.Immutable;

public sealed class WhenChainIsCalled
{
    private const string Value = "var result = query.Where(x => x.IsActive).OrderBy(x => x.Name).Select(x => x.Id).ToList();";

    [Fact]
    public void GivenFluentInvocationWhenLineIsLongThenSplitsByDots()
    {
        // Arrange
        var subject = new OneDotPerLineChain();

        // Act
        ImmutableArray<string> result = subject.Chain(Value, 20);

        // Assert
        result.ShouldBe(
        [
            "var result = query",
            "    .Where(x => x.IsActive)",
            "    .OrderBy(x => x.Name)",
            "    .Select(x => x.Id)",
            "    .ToList();",
        ]);
    }
}
