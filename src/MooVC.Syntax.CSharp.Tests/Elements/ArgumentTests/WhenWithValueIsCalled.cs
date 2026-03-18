namespace MooVC.Syntax.CSharp.Elements.ArgumentTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithValueIsCalled
{
    private const string Value = "42";

    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var argument = new Argument();
        var value = Snippet.From(Value);

        // Act
        Argument result = argument.WithValue(value);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(argument);
        _ = await Assert.That(result.Value).IsEqualTo(value);
        _ = await Assert.That(argument.Value).IsNotEqualTo(value);
    }
}