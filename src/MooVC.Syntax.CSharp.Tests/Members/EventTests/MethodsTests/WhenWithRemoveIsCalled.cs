namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithRemoveIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        var remove = Snippet.From("result");

        // Act
        Event.Methods result = original.WithRemove(remove);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Remove.ShouldBe(remove);
        result.Add.ShouldBe(original.Add);
        original.Remove.ShouldBe(Snippet.Empty);
    }
}