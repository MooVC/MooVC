namespace MooVC.Syntax.CSharp.Elements.ArgumentTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithNameIsCalled
{
    private const string Name = "Value";

    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var argument = new Argument();
        var name = new Variable(Name);

        // Act
        Argument result = argument.WithName(name);

        // Assert
        result.ShouldNotBeSameAs(argument);
        result.Name.ShouldBe(name);
        argument.Name.ShouldNotBe(name);
    }
}