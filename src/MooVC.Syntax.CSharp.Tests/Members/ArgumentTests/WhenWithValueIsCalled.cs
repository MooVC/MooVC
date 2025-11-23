namespace MooVC.Syntax.CSharp.Members.ArgumentTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithValueIsCalled
{
    private const string Value = "42";

    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var argument = new Argument();
        Snippet value = Snippet.From(Value);

        // Act
        Argument result = argument.WithValue(value);

        // Assert
        result.ShouldNotBeSameAs(argument);
        result.Value.ShouldBe(value);
        argument.Value.ShouldNotBe(value);
    }
}
