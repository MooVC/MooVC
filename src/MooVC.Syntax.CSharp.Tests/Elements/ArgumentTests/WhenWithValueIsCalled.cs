namespace MooVC.Syntax.CSharp.Elements.ArgumentTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithValueIsCalled
{
    private const string Value = "42";

    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var argument = new Argument();
        var value = Snippet.From(Value);

        // Act
        Argument result = argument.WithValue(value);

        // Assert
        result.ShouldNotBeSameAs(argument);
        result.Value.ShouldBe(value);
        argument.Value.ShouldNotBe(value);
    }
}