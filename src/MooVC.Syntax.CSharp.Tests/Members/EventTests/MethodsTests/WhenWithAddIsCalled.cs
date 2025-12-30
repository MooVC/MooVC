namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithAddIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Event.Methods
        {
            Remove = Snippet.From("value"),
        };

        var add = Snippet.From("result");

        // Act
        Event.Methods result = original.WithAdd(add);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Add.ShouldBe(add);
        result.Remove.ShouldBe(original.Remove);
        original.Add.ShouldBe(Snippet.Empty);
    }
}