namespace MooVC.Syntax.CSharp.Members.ArgumentTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithModifierIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var argument = new Argument();

        // Act
        Argument result = argument.WithModifier(Argument.Mode.In);

        // Assert
        result.ShouldNotBeSameAs(argument);
        result.Modifier.ShouldBe(Argument.Mode.In);
        argument.Modifier.ShouldNotBe(Argument.Mode.In);
    }
}
