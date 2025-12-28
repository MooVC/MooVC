namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.OptionsTests;

public sealed class WhenWithNamingIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Argument.Options();
        Identifier.Options value = Identifier.Options.Pascal;

        // Act
        Argument.Options result = options.WithNaming(value);

        // Assert
        result.ShouldNotBeSameAs(options);
        result.Naming.ShouldBe(value);
        options.Naming.ShouldNotBe(value);
    }
}